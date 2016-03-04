/*
 * Data access methods for Discount
 */

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace DAO.Data
{
    public interface DiscountDAO
    {
        List<Discount> getAllDiscounts();
        List<Discount> getDiscountByStore(Store store);
    }
}
