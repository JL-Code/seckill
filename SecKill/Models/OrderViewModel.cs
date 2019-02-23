using System;
using System.ComponentModel.DataAnnotations;

namespace SecKill.Models
{
    public class OrderViewModel
    {

        [Required]
        public Guid? OrderId { get; set; }

        [Required]
        public Guid? GoodsId { get; set; }

        public string GoodsName { get; set; }

        public double GoodsPrice { get; set; }

        [Range(1, 1, ErrorMessage = "商品数量非法")]
        public int Quantity { get; set; }

        [Required]
        public string Address { get; set; }
    }

    public class OrderDraftViewModel
    {
        [Required]
        public Guid? GoodsId { get; set; }

        public Guid OrderId { get; set; }

        public string GoodsName { get; set; }

        public double GoodsPrice { get; set; }
    }
}
