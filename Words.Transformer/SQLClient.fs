namespace Words.Transformer

open System.Data
open MySqlConnector
open System

type SqlClient(config) =
    let connection = new MySqlConnection(config)
    let mutable transaction: MySqlTransaction = null

    let getCommand command (parameters: obj[]) =
        let sqlCommand = new MySqlCommand(command, connection, transaction)

        for i = 0 to parameters.Length - 1 do
            sqlCommand.Parameters.AddWithValue("@p" + string (i + 1), parameters.[i]) |> ignore

        sqlCommand
    let getParts (command: FormattableString) =
        let parameters = command.GetArguments()

        let command =
            parameters
            |> Array.indexed
            |> Array.fold (fun (command: string) (index, _) ->
                command.Replace ("{" + string index + "}", "@p" + string (index + 1))
            ) command.Format

        command, parameters

    member _.Execute (command, parameters) =
        use sqlCommand = getCommand command parameters
        let rowsAffected = sqlCommand.ExecuteNonQuery()
        
        if command.ToLower().StartsWith "insert " then
            int sqlCommand.LastInsertedId
        else
            rowsAffected
    member this.Execute command =
        let sql, inputs = getParts command
        this.Execute (sql, inputs)
        
    member this.Transaction handler =
        if connection.State <> ConnectionState.Open then
            connection.Open()
        
        try
            let tr = connection.BeginTransaction()
            transaction <- tr
            
            try
                handler()
                tr.Commit()
            with
            | error ->
                printfn $"%A{error}"
                tr.Rollback()
        finally
            connection.Close()