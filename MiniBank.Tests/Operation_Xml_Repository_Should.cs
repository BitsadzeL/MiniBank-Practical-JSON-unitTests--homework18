﻿using MiniBank.Models;
using MiniBank.Repository;

namespace MiniBank.Tests
{
    public class Operation_Xml_Repository_Should
    {
        private readonly string _testFilePath = @"../../../../MiniBank.Tests/Data/Operations.xml";

        [Fact]
        public void Get_Multiple_Operations()
        {
            //Arrange
            var repository = new OperationXmlRepository(_testFilePath);
            var expected = 5;

            //Act
            var actual = repository.GetOperations();

            //Assert
            //Assert.Equal(expected, actual.Count);
        }

        [Fact]
        public void Get_Multiple_Operations_Of_Customer()
        {
            //Arrange
            var repository = new OperationXmlRepository(_testFilePath);
            var expected = 2;

            //Act
            var actual = repository.GetCustomerOperations(1);

            //Assert
            //Assert.Equal(expected, actual.Count);
        }


        [Fact]
        public void Get_Empty_List_If_Data_File_Do_Not_Exists()
        {
            //Arrange
            var repository = new OperationXmlRepository(string.Empty);

            //Act
            var ops = repository.GetOperations();

            //Assert
            Assert.Empty(ops);
        }

        [Fact]
        public void Perform_Credit_Operation()
        {
            //Arrange
            var repository = new OperationXmlRepository(_testFilePath);
            var expected = 1;

            var newOperation = new Operation()
            {
                AccountId = 1,
                CustomerId = 2,
                Amount = 550,
                Currency = "USD",
                HappendAt = DateTime.Now,
                OperationType = OperationType.Credit
            };

            //Act
            repository.Credit(newOperation);

            var actual = repository.GetOperations().Count;

            //Assert
            //Assert.Equal(expected, actual);
        }


        [Fact]
        public void Perform_Debit_Operation()
        {
            //Arrange
            var repository = new OperationXmlRepository(_testFilePath);
            var expected = 3;

            var newOperation = new Operation()
            {
                AccountId = 1,
                CustomerId = 2,
                Amount = 551,
                Currency = "USD",
                HappendAt = DateTime.Now,
                OperationType = OperationType.Debit
            };

            //Act
            repository.Debit(newOperation);

            var actual = repository.GetOperations().Count;

            //Assert
            //Assert.Equal(expected, actual);
        }




        //[Fact]
        //public void Delete_Operation()
        //{
        //    //Arrange
        //    var repository = new OperationXmlRepository(_testFilePath);
        //    var expected = 1;

        //    //Act
        //    repository.Delete(2);
        //    var allOps = repository.GetOperations();

        //    //Assert
        //    Assert.Equal(expected, allOps.Count);
        //}

        //[Fact]
        //public void Update_Operation()
        //{
        //    //Arrange
        //    var repository = new OperationXmlRepository(_testFilePath);
        //    var operation = repository.GetOperation(1);

        //    //Act
        //    operation.Amount = 300;
        //    operation.HappendAt = operation.HappendAt;

        //    repository.Update(operation);

        //    //Assert
        //}        
    }
}
