using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Quiron.LojaVirtual.Dominio.Entidades
{
    public class Pedido
    {
        [Key]
        public int PedidoId { get; set; }

        //Nome
        [Required(ErrorMessage="Nome Obrigatório")]
        [Display(Name="Nome")]
        public string  Nome { get; set; }

        //Cep
        [Required(ErrorMessage="Cep Obrigatório")]
        public string Cep { get; set; }

        //Endereco
        [Required(ErrorMessage="Endereço Obrigatório")]
        [Display(Name="Endereço")]
        public string Endereco { get; set; }

        //Complemento
        [Required(ErrorMessage="Complemento Obrigatório")]
        public string Complemento { get; set; }

        //Cidade
        [Required(ErrorMessage="Cidade Obrigatório")]
        public string Cidade { get; set; }

        //Bairro
        [Required(ErrorMessage="Bairro Obrigatório")]
        public string Bairro { get; set; }

        //Estado
        [Required(ErrorMessage="UF Obrigatório")]
        public string Estado { get; set; }

        //Email
        [Required(ErrorMessage="E-mail obrigatório.")]
        [EmailAddress(ErrorMessage="E-mail invalido.")]
        [Display(Name="E-mail")]
        public string Email { get; set; }

        //Embrulhar
        [Display(Name="Deseja Embrulhar o Presente")]
        public bool EmbrulharPresente { get; set; }
    }
}
