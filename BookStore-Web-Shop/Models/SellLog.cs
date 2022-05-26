﻿using BookStore_Web_Shop.Validation;

namespace BookStore_Web_Shop.Models
{
    public class SellLog
    {
        [key]
        public string Id { get; set; } 
        public DateTime Date { get; set; }
        [MoreThan0Validation]
        public int Quantity { get; set; }   
        
        public SellLog()
        {
        }
        public SellLog(DateTime date, int quantity)
        {
            Date = date;
            Quantity = quantity;
        }

        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
