using System;
using System.Collections.Generic;
using System.Text;

namespace SlimFormaturas.Domain.Entities {
    public class Product : Entity{
        public Product() {
            ProductId = Guid.NewGuid().ToString();
        }

        public string ProductId { get; set; }
        public string Nome { get; set; }
        public string CodigoInterno { get; set; }
        //Grupo de produto
        public bool MovimentoEstoque { get; set; }
        public bool PossuiVariacoes { get; set; }
        //Tipo de Unidade { get; set; }
        //Detalhes
        public int Peso { get; set; }
        public int Largura { get; set; }
        public int Altura { get; set; }
        public int Comprimento { get; set; }
        public bool Ativo { get; set; }
        public bool ComercializaNaCentralDoCliente { get; set; }
        public int ComissaoPadrão { get; set; }
        public string Descricao { get; set; }
        //Estoque
        public int Minimo { get; set; }
        public int Maximo { get; set; }
        public int atual { get; set; }
        //Forncedores
        //Fornecedor { get; set; }
        //Fotos
        public string Foto { get; set; }
        //Valores
        public int ValordeCusto { get; set; }
        public int OutrasDespesas { get; set; }
        public int CustoFinal { get; set; }
    }
}
