using System;
using Xunit;

namespace GradeBook.Tests
{
    public class TypeTests
    {
        [Fact]
        public void Test1(){
            var x = GetInt();
            SetInt(ref x);
            Assert.Equal(42,x);
        }

        private void SetInt(ref int z)
        {
            z = 42;
        }

        private int GetInt()
        {
            return 3; 
        }

        [Fact]
        public void CSharpIsPassByReference()
        {
            // arrange
            var book1 = GetBook("Book one");
            GetBookSetName(out book1,"New name");
            // act

            // assert
            Assert.Equal("New name",book1.Name);
        }

        private void GetBookSetName(out Book book, string name)
        {
            book = new Book(name);
        }
        [Fact]
        public void CSharpIsPassByValue()
        {
            // arrange
            var book1 = GetBook("Book one");
            GetBookSetName(book1,"New name");
            // act

            // assert
            Assert.Equal("Book one",book1.Name);
        }

        private void GetBookSetName(Book book, string name)
        {
            book = new Book(name);
            book.Name = name;
        }

        [Fact]
        public void CanSetNameFromReference()
        {
            // arrange
            var book1 = GetBook("Book one");
            SetName(book1,"New name");
            // act

            // assert
            Assert.Equal("New name",book1.Name);
        }

        private void SetName(Book book, string name)
        {
            book.Name = name;
        }

        [Fact]
        public void StringsBehaveLikeAValueType()
        {
            string name = "Daniel";
            var upper = MakeUppercase(name);

            Assert.Equal("Daniel",name);
            Assert.Equal("DANIEL",upper);
        }

        private string MakeUppercase(string parameter)
        {
           return parameter.ToUpper();
        }

        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
            // arrange
            var book1 = GetBook("Book one");
            var book2 = GetBook("Book two");
            // act

            // assert
            Assert.Equal("Book one",book1.Name);
            Assert.Equal("Book two",book2.Name);
            Assert.NotSame(book1,book2);
        }

        [Fact]
        public void TwoVarsCanReferenceSameObject()
        {
            // arrange
            var book1 = GetBook("Book one");
            var book2 = book1;
            // act

            // assert
            Assert.Same(book1,book2);
            Assert.True(Object.ReferenceEquals(book1,book2));
            
        }

        Book GetBook(string name)
        {
            return new Book(name);
        }
    }
}