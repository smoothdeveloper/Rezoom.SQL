﻿module Rezoom.SQL.Test.CreateSchema
open Rezoom.SQL.Compiler
open NUnit.Framework

[<Test>]
let ``schema can contain table`` () =
    { defaultTest with
        Migration = """
            create schema fancy_schema;
            create table fancy_schema.fancy_table (fancy_column int);
        """
        Command = "insert into fancy_schema.fancy_table (fancy_column) values (1)"
        Expect = Good expect
    } |> assertSimple
