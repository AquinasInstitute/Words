using Words.Addons;

namespace Words.Data_Sources;

public interface IDictionaryDataSource
{
    WordTables LoadWords(LatinDictionarySettings settings, LatinDictionary dictionary);
    (InflectionMaps mapping, Inflection.Inflection[] inflections) LoadInflections(LatinDictionarySettings settings);
    (Prefix[] prefixes, Suffix[] suffixes, Tackon[] tackons, Tackon[] packons) LoadAddons(LatinDictionarySettings settings);

    void CleanUp();
}