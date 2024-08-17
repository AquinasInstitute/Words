const searchTerm = document.getElementById("search-term");

const searchButton = document.getElementById("search-button");
const clearButton = document.getElementById("clear-button");

const latinOutput = document.getElementById("latin-output");
const englishOutput = document.getElementById("english-output");

const sharedOutput = document.getElementById("shared-output");

const latinSearches = new Map();
const englishSearches = new Map();

/**
 * @param tagName {string}
 * @param attributes { Partial<HTMLElement> }
 * @param children { HTMLElement[] }
 */
const $ = function (tagName, attributes, children = [])
{
    const element= document.createElement(tagName);
    
    for (const key of Object.getOwnPropertyNames(attributes))
    {
        element[key] = attributes[key];
    }
    
    for (const child of children)
    {
        element.appendChild(child);
    }
    
    return element;
};

let outputId = 0;

/**
 * @param query {string}
 * @param contents {string}
 * @param output {HTMLElement}
 * @param searches {Map<string, string>}
 */
const renderOutput = function (query, contents, output, searches) {
    const makeDisplay = (trueId, baseId) =>
    {
        const wrapper = $("div", {
            className: "flex flex-col rounded-md m-2 border whitespace-pre-wrap monospace min-w-entry",
            id: trueId
        }, [
            $("div", {}, [
                $("div", { className: "float-left" }, [
                    $("div", { className: "text-xl font-bold", textContent: query })
                ]),
                $("div", { className: "float-right" }, [
                    $("img", {
                        src: "./icons/x.svg",
                        className: "p-2 cursor-pointer icon",
                        onclick: () => {
                            const specific = document.getElementById(baseId + "-specific");
                            specific.parentNode.removeChild(specific);

                            const shared = document.getElementById(baseId + "-shared");
                            shared.parentNode.removeChild(shared);
                            
                            searches.delete(query);
                        }
                    })
                ])
            ])
        ]);

        const displayBox = $("div", { className: "w-full", innerHTML: contents });
        wrapper.append(displayBox);
        
        return wrapper;
    }

    searches.set(query, outputId.toString());
    
    output.prepend(makeDisplay(outputId.toString() + "-specific", outputId.toString()));
    sharedOutput.prepend(makeDisplay(outputId.toString() + "-shared", outputId.toString()));
    
    outputId++;
};

const performSearch = function () {
    const query = searchTerm.value.toLowerCase().trim();

    // Don't try to search for nothing.
    // Server will handle this case, but no reason to send an extra request.
    if (query === "") return;
    
    /**
     * @param query {string}
     * @param searches {Map<string, string>}
     * @param container {HTMLElement}
     */
    const focusResult = (query, searches, container) =>
    {
        const baseId = searches.get(query);
        if (baseId == null) return;
        
        const specific = document.getElementById(`${baseId}-specific`);
        container.removeChild(specific);
        container.prepend(specific);
        
        const shared = document.getElementById(`${baseId}-shared`);
        sharedOutput.removeChild(shared);
        sharedOutput.prepend(shared);
    };
    
    if (latinSearches.has(query) && englishSearches.has(query))
    {
        focusResult(query, englishSearches, englishOutput);
        focusResult(query, latinSearches, latinOutput);
        
        searchTerm.value = "";
        return;
    }
    
    const spin = setTimeout(() =>
    {
        searchButton.classList.add("spinner");
    }, 100);
    
    fetch("/api/Words/Lookup/" + query)
        .then(res => res.json())
        .then(response =>
        {
            clearTimeout(spin);
            searchButton.classList.remove("spinner");
            
            const latin = response.latin;
            const english = response.english;

            let foundLatin = false;
            let foundEnglish = false;

            foundLatin = latin != null && latin !== "";
            foundEnglish = english != null && english !== "";
            
            if (foundLatin) {
                if (latinSearches.has(query)) {
                    focusResult(query, latinSearches, latinOutput);
                }
                else {
                    renderOutput(query, latin, latinOutput, latinSearches);
                }
            }
            if (foundEnglish) {
                if (englishSearches.has(query)) {
                    focusResult(query, englishSearches, englishOutput);   
                }
                else {
                    renderOutput(query, english, englishOutput, englishSearches);
                }
            }
            
            searchTerm.classList.remove("failure");

            if (foundLatin || foundEnglish) {
                searchTerm.value = "";
            }
            else {
                searchTerm.classList.add("failure");
            } 
        });
};

searchTerm.addEventListener("keyup", event => {
    searchTerm.classList.remove("failure");
    
    if (event.key === "Enter") {
        performSearch();
    }
});
searchButton.addEventListener("click", () => performSearch())

const emptyNode = (node) =>
{
    while (node.firstChild)
    {
        node.removeChild(node.lastChild);
    }
};

clearButton.addEventListener("click", () =>
{
    latinSearches.clear();
    englishSearches.clear();
    
    emptyNode(latinOutput);
    emptyNode(englishOutput);
    emptyNode(sharedOutput);
})