using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoIoC
{
    public class Book
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public Category Cate { get; set; }

        //IoC
        //pass category obj in contructor => IOC
        public Book(Category cate) {
            //book object depends on Category object
            //            Cate = new Category();
            Cate = cate;
        }
        public Book(int id, string title, Category cate) :this(cate) {
            Id = id;
            Title = title;
        }
    }
}
