using System;
using System.Collections.Generic;

namespace Unit3
{
    public class Item 
    {
        private string _name;

        private int _quantity;

        private decimal _price;

        public Item(string name, decimal price) {
            _name = name;
            _quantity = 0;
            _price = price;
        }

        public void ReceiveQuantity(int quantity) {
            // Validate quantity
            _quantity += quantity;
            Console.WriteLine($"Received {quantity} of item {_name}");

        }

        public decimal SellItem(int quantityToSell, decimal amountPaid) {
            if (quantityToSell > _quantity) {
                Console.WriteLine("Not enough quantity to sell. Transaction canceled");
                return 0m; //should throw
            }

            decimal change = amountPaid - _price * Convert.ToDecimal(quantityToSell);
            if (change < 0) {
                Console.WriteLine("Not enough money. Transaction canceled");
                return 0m;//should throw
            }

            _quantity -= quantityToSell;
            Console.WriteLine($"Sold {quantityToSell} of item {_name}");
            return change;
        }

        public string GetStatus() {
            string s = "----------\n";
            s += $"Item: {_name}\n";
            s += $"Quantity: {_quantity}\n";
            s += $"Price: {_price}\n";
            s += "----------\n";
            return s;
        }
    }
}
