using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkCredential;
namespace Quiron.LojaVirtual.Dominio.Entidades
{

    public class EmailPedido
    {
        private readonly EmailConfiguracoes _emailconfiguracoes;

        public EmailPedido(EmailConfiguracoes emailconfiguracoes)
        {
            _emailconfiguracoes = emailconfiguracoes;
        }

        public void ProcessarPedido(Carrinho carrinho, Pedido pedido)
        {
            using(var smtpclient = new SmtpClient())
            {
                smtpclient.EnableSsl = _emailconfiguracoes.UsarSsl;
                smtpclient.Host = _emailconfiguracoes.ServidorSmtp;
                smtpclient.Port = _emailconfiguracoes.ServidorPorta;
                smtpclient.UseDefaultCredentials = false;
                smtpclient.Credentials = new System.Net.NetworkCredential(_emailconfiguracoes.Usuario, 
                                                                          _emailconfiguracoes.ServidorSmtp);

                if(_emailconfiguracoes.EscreverArquivo)
                {
                    //gravar em uma determinada pasta que informar
                    smtpclient.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
                    smtpclient.PickupDirectoryLocation = _emailconfiguracoes.PastaArquivo;
                    smtpclient.EnableSsl = false;
                }

                StringBuilder body = new StringBuilder()
                .AppendLine("Novo Pedido")
                .AppendLine("-------------")
                .AppendLine("Itens:");

                foreach(var x in carrinho.ItensCarrinho)
                    body.AppendFormat("{0} x {1}: SubTotal {2:c}", 
                                        x.Quantidade, 
                                        x.Produto.Nome, 
                                        x.Produto.Preco * x.Quantidade);

                body.AppendFormat("Valor total do pedido: {0:c}", carrinho.ObterValorTotal())
                    .AppendLine("-------------------------------")
                    .AppendLine("Anviar Para")
                    .AppendLine(pedido.Nome)
                    .AppendLine(pedido.Email)
                    .AppendLine(pedido.Endereco ?? "")
                    .AppendLine(pedido.Complemento ?? "")
                    .AppendLine(pedido.Cep)
                    .AppendLine(pedido.Cidade ?? "")
                    .AppendLine(pedido.Estado ?? "")
                    .AppendLine(pedido.Bairro ?? "")
                    .AppendLine("-------------------------------")
                    .AppendLine("Embrulhar para presete?" + (pedido.EmbrulharPresente ? "Sim" : "Não" ));


                MailMessage mailMessage = new MailMessage(_emailconfiguracoes.De, _emailconfiguracoes.Para, "Novo Pedido", body.ToString());

                if(_emailconfiguracoes.EscreverArquivo)
                    mailMessage.BodyEncoding = Encoding.GetEncoding("ISO-8859-1");

                smtpclient.Send(mailMessage);
            }
        }
    }

}
