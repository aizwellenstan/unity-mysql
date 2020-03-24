using UnityEngine;
using System;
using System.Collections;

using MySql.Data;
using MySql.Data.MySqlClient;

public class MySQLTest : MonoBehaviour {

    string SERVER    = "localhost";
    string DATABASE  = "database";
    string USERID    = "root";
    string PORT      = "3306";
    string PASSWORD  = "pass";
        string TABLENAME = "hoge";

    void Start () {

        StartCoroutine ( SelectData () );

    }

    IEnumerator SelectData () {

        MySqlConnection con = null;

        string conCmd = 
                "server="+SERVER+";" +
                "database="+DATABASE+";" +
                "userid="+USERID+";" +
                "port="+PORT+";" +
                "password="+PASSWORD;

        try {

            con = new MySqlConnection( conCmd );
            con.Open ();

        } catch (MySqlException ex){
            Debug.Log ( ex.ToString() );
        }

        string selCmd = "SELECT * FROM TABLENAME LIMIT 0, 1200;";

        MySqlCommand cmd = new MySqlCommand( selCmd, con );

        IAsyncResult iAsync = cmd.BeginExecuteReader ();

        while ( !iAsync.IsCompleted ){
            yield return 0;
        }

        MySqlDataReader rdr = cmd.EndExecuteReader ( iAsync );

        while ( rdr.Read() ) {
            if( !rdr.IsDBNull ( rdr.GetOrdinal ("ID") ) ){
                //Debug.Log ( "ID : " + rdr.GetString ("ID") );
            }
        }

        rdr.Close ();
        rdr.Dispose ();
        con.Close ();
        con.Dispose ();
    }
}