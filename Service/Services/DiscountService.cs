using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Service.Services
{
    public interface DiscountService
    {
       //Create a discount level and set the percentage discount
        void createDiscoutForStore(int storeId);

       //Provide a means to set a spending level that graduates a customer to the next discount
        void setDiscountFromSpendingLevel(Customer customer, double spendingLevel);

       //Provide a means of creating a custom discount whenever the user wishes
        void applyCustomDiscountToCustomer(Customer customer, Discount discount);

       //Provide a means of viewing all discounts
        List<Discount> viewStoreDiscountRates(int storeId);

       //Provide a means of editing or removing discounts
        void removeDiscount(int discountId);
        void editDiscout(Discount discount);

    }
}
