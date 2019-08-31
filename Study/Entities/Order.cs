using System;
using System.Collections.Generic;
using System.Text;
using Study.Entities.Enums;
using System.Globalization;

namespace Study.Entities
{
    class Order
    {
        public DateTime Moment { get; set; }
        public OrderStatus Status { get; set; }
        public Client Client { get; set; }
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();

        public Order()
        {

        }

        public Order(DateTime moment, OrderStatus status, Client client)
        {
            Moment = moment;
            Status = status;
            Client = client;
        }

        public void AddItem(OrderItem item)
        {
            Items.Add(item);
        }
        public void RemoveItem(OrderItem item)
        {
            Items.Remove(item);
        }

        public double Total()
        {
            double total = 0;
            foreach(OrderItem it in Items)
            {
                total += it.subTotal();
            }

            return total;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Order moment: ");
            sb.AppendLine(Moment.ToString());
            sb.Append("Order status: ");
            sb.AppendLine(Status.ToString());
            sb.Append("Client: ");
            sb.Append(Client.Name + " ");
            sb.Append("(" + Client.BirthDate.ToShortDateString() + ")");
            sb.Append(" - ");
            sb.AppendLine(Client.Email);    
            sb.AppendLine("Order items:");

            foreach(OrderItem it in Items)
            {
                sb.Append(it.Product.Name + ", " + it.Price.ToString("F2",CultureInfo.InvariantCulture) + " ");
                sb.Append("Quantity: ");
                sb.Append(it.Quantity + " ");
                sb.Append("Subtotal: $");
                sb.Append(it.subTotal().ToString("F2", CultureInfo.InvariantCulture));
                sb.AppendLine();
                    
            }
            sb.Append("Total price: $");
            sb.AppendLine(Total().ToString("F2", CultureInfo.InvariantCulture));
            return sb.ToString();

        }
    }
}
