using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace DAO.Data
{
    public interface InventoryDAO
    {
        List<Inventory> getAllInventories();
        Inventory getInventoryById(int id);
    }
}
