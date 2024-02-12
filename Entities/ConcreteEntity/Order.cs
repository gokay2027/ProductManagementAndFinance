﻿using Entities.AbstractEntity;

namespace Entities.ConcreteEntity
{
    public class Order : BaseEntity
    {
        public List<Product> Products { get; private set; } = new List<Product>();
        public float TotalPrice { get; private set; } = 0;
        public string Adress { get; private set; }

        public Guid UserId { get; private set; }
        public User User { get; private set; }

        public Order()
        {
        }

        public Order(Guid userId, string adress)
        {
            UserId = userId;
            Adress = adress;
        }

        public void UpdateOrder(Guid userId, float totalPrice, string adress)
        {
            UserId = userId;
            TotalPrice = totalPrice;
            Adress = adress;
            SetUpdateDate();
        }

        public void SetTotalPrice(float price)
        {
            TotalPrice = price;
        }

        public void AddProductToOrder(Product product)
        {
            Products.Add(product);
            TotalPrice += product.Price;
        }

        public void DeleteProductFromOrder(Guid productId)
        {
            var product = Products.FirstOrDefault(a => a.Id.Equals(productId));
            Products.Remove(product);
            TotalPrice -= product.Price;
        }
    }
}