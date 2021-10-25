using System.Collections.Generic;
using InnoTech.LegosForLife.Core.Models;

namespace InnoTech.LegosForLife.Domain.Test
{
    public interface IProductRepository
    {
        List<Product> FindAll();
    }
}