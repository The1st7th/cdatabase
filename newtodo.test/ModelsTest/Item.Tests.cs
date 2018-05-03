using System.Collections.Generic;
using MySql.Data.MySqlClient;
using ToDoList;
using System;
using ToDoList.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ToDoListTest.Models
{
    [TestClass]
    public class ItemTests : IDisposable
    {
      public void Dispose()
        {
            Item.DeleteAll();
        }
      public ItemTests()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=todo_test;";
        }

    [TestMethod]
      public void GetAll_DbStartsEmpty_0()
      {
        int result = Item.GetAll().Count;

        Assert.AreEqual(0, result);
      }
    [TestMethod]
      public void Save_SavesToDatabase_ItemList()
      {
        Item testItem = new Item("Mow the grass");
        Console.WriteLine(testItem.GetDescription());
        testItem.save();
        List<Item> result = Item.GetAll();
        List<Item> testList = new List<Item>{testItem};

        CollectionAssert.AreEqual(testList, result);
      }
      [TestMethod]
      public void Save_AssignsIdToObject_Id()
      {
        //Arrange
        Item testItem = new Item("Mow the lawn");

        //Act
        testItem.save();
        Item savedItem = Item.GetAll()[0];

        int result = savedItem.GetId();
        int testId = testItem.GetId();

        //Assert
        Assert.AreEqual(testId, result);
      }
      [TestMethod]
      public void Find_FindsItemInDatabase_Item()
      {
        //Arrange
        Item testItem = new Item("Mow the lawn");
        testItem.save();

        //Act
        Item foundItem = Item.Find(testItem.GetId());

        //Assert
        Assert.AreEqual(testItem, foundItem);
      }
      [TestMethod]
      public void Edit_UpdatesItemInDatabase_String()
      {
        //Arrange
        string firstDescription = "Walk the Dog";
        Item testItem = new Item(firstDescription, 1);
        testItem.save();
        string secondDescription = "Mow the lawn";

        //Act
        testItem.Edit(secondDescription);

        string result = Item.Find(testItem.GetId()).GetDescription();

        //Assert
        Assert.AreEqual(secondDescription , result);
      }
    }
    }
