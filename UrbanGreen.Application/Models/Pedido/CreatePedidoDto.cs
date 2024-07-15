﻿using System.ComponentModel.DataAnnotations;

namespace UrbanGreen.Application.Models.Pedido
{
    public class CreatePedidoDto
    {
        [Required]
        public DateTime Data { get; set; }
        [Required(ErrorMessage = "O nome do comprador é obrigatório")]
        public string NomeComprador { get; set; }
        [Required]
        //public int ItemPedidoId { get; set; }
        public List<int> ItensPedidoIds { get; set; }
    }
}