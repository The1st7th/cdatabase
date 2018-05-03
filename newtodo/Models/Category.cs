using System.Collections.Generic;
using MySql.Data.MySqlClient;
using ToDoList;
using System;

namespace ToDoList.Models
{
    public class Category
    {
      private int _id;
      private string _type;

    public Category (string type, int id =0){
      _id = id;
      _type = type;
    }

    public int GetId()
    {
      return _id;
    }
    public string GetDescription()
    {
      return _type;
    }

      public static List<Category> GetAll()
      {
          List<Category> allItems = new List<Category> {};
          MySqlConnection conn = DB.Connection();
          conn.Open();
          MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
          cmd.CommandText = @"SELECT * FROM category;";
          MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
          while(rdr.Read())
          {
            int itemId = rdr.GetInt32(0);
            string itemDescription = rdr.GetString(1);
            Category newItem = new Category(itemDescription, itemId);
            allItems.Add(newItem);
          }
          conn.Close();
          if (conn != null)
          {
              conn.Dispose();
          }
          return allItems;
      }
}
}
