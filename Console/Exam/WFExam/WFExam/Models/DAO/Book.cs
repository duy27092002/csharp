using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFExam.Models
{
    class Book
    {
        string author;
        public string Author
        {
            get 
            {
                return this.author;
            }
            set
            {
                this.author = value;
            }
        }

        int pages;

        string isbn;
        public string ISBN
        {
            get
            {
                return this.isbn;
            }
        }

        string title;
        public string Title 
        {
            get
            {
                return this.title;
            }
            set
            {
                this.title = value;
            }
        }

        int currentPage;

        public Book()
        {
            this.currentPage = 1;
        }

        public Book(string author, int pages, string isbn, string title, int currentPage)
        {
            this.author = author;
            this.pages = pages;
            this.isbn = isbn;
            this.title = title;
            this.currentPage = currentPage;
        }

        // lật sang trang sau
        public void filpPageForward(int currentPage)
        {

        }

        // lật về trang trước
        public void filpPageBackward(int currentPage)
        {

        }
    }
}
