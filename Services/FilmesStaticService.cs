using Locadora.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Locadora.Services
{
    public class FilmesStaticService : IFilmesService
    {
        public List<Filmes> getFilme()
        {
            List<Filmes> listaFilme = new List<Filmes>();
            listaFilme.Add(new Filmes { Id = 1, Nome = "Velozes & Furiosos 9", Sinopse = Sinopse(1), Duracao = "2h 23min", Lancamento = new DateTime(2021, 06, 24), Genero = "Text" });
            listaFilme.Add(new Filmes { Id = 2, Nome = "Um Lugar Silencioso", Sinopse = Sinopse(2), Duracao = "1h 37min", Lancamento = new DateTime(2021, 07, 22), Genero = "Text" });
            listaFilme.Add(new Filmes { Id = 3, Nome = "Os Croods 2: Uma Nova Era", Sinopse = Sinopse(3), Duracao = "1h 36min", Lancamento = new DateTime(2021, 07, 01), Genero = "Text" });
            listaFilme.Add(new Filmes { Id = 4, Nome = "Sibyl", Sinopse = Sinopse(4), Duracao = "1h 39min", Lancamento = new DateTime(2021, 07, 15), Genero = "Text" });
            listaFilme.Add(new Filmes { Id = 5, Nome = "O Charlatão", Sinopse = Sinopse(5), Duracao = "1h 58min", Lancamento = new DateTime(2021, 07, 08), Genero = "Text" });
            listaFilme.Add(new Filmes { Id = 6, Nome = "A Boa Esposa", Sinopse = Sinopse(6), Duracao = "1h 49min", Lancamento = new DateTime(2021, 07, 17), Genero = "Text" });
            listaFilme.Add(new Filmes { Id = 7, Nome = "Um Lugar Silencioso", Sinopse = Sinopse(7), Duracao = "1h 30min", Lancamento = new DateTime(2018, 04, 05), Genero = "Text" });
            listaFilme.Add(new Filmes { Id = 8, Nome = "O Oficial e o Espião", Sinopse = Sinopse(8), Duracao = "2h 12min", Lancamento = new DateTime(2020, 03, 12), Genero = "Text" });
            listaFilme.Add(new Filmes { Id = 9, Nome = "Veneza", Sinopse = Sinopse(9), Duracao = "1h 50min", Lancamento = new DateTime(2021, 06, 17), Genero = "Text" });
            listaFilme.Add(new Filmes { Id = 10, Nome = "Maus Hábitos", Sinopse = Sinopse(10), Duracao = "1h 48min", Lancamento = new DateTime(1999, 02, 15), Genero = "Text" });
            return listaFilme;
        }
        private string Sinopse(int? id)
        {
            string velozesFuriosos = "Dom precisa reunir a equipe novamente para enfrentar seu irmão desaparecido Jakob, um assassino habilidoso e motorista excelente, que está trabalhando ao lado de Cipher.";
            string UmLugarSilencioso = "A família Abbott tenta seguir a vida após acontecimentos aterrorizantes, mas as ameaças ainda não acabaram.";
            string OsCroods2_UmaNovaEra = "Sequência de Os Croods (2013), aventura sobre uma família pré-histórica que descobre as transformações no mundo enquanto tenta permanecer unida.";
            string Sibyl = "Uma psicoterapeuta encontra em uma de suas pacientes a possibilidade perfeita pa escrever seu novo romance.";
            string OCharlatão = "O Charlatão acompanha a história de Jan Mikolasek, um curandeiro tcheco que ganha fama com seus tratamentos não ortodoxos, prometendo curar inúmeras doenças. Com a chegada do regime ditadorial nazista, o herborista aumenta ainda mais reputação conquistando uma fortuna.";
            string ABoaEsposa = "Paulette e o marido administram uma escola que ensina meninas a serem boas donas de casa. Após a morte repentina de seu marido, Paulette descobre que a escola está à beira da falência e tem que assumir suas responsabilidades.";
            string UmLugar_Silencioso = "Uma criatura assustadora dizima a população da Terra repentinamente. Para sobreviver, é preciso se manter em total silêncio.";
            string OOficialeoEspião = "Em Paris, final do século 19, o capitão francês Alfred Dreyfus é um dos poucos judeus que faz parte do exército. No dia 22 de dezembro de 1884, seus inimigos alcançam o objetivo de fazer com que Dreyfus seja acusado de alta traição e o capitão é sentenciado à prisão perpétua no exílio. Intrigado com a evolução do caso, o investigador Picquart decide desvendar o mistério que há trás da condenação. ";
            string Veneza = "Reencontrar o único homem que amou é o sonho de Gringa (Carmen Maura), dona de um bordel no interior do Brasil. Mesmo cega e muito doente, ela insiste em realizar seu último desejo: ir até Veneza para pedir perdão ao amante que abandonou, décadas atrás. Para levá-la à cidade italiana, Tonho (Eduardo Moscovis), Rita (Dira Paes) e as outras ...";
            string MausHábitos = "Yolanda Bel (Cristina Sánchez Pascual) é uma cantora de cabaré que leva uma vida desregrada até o dia em que presencia a morte por overdose de seu namorado. Procurada pela polícia, ela decide buscar refúgio no convento das Redentoras Humilhadas, cuja Madre Superiora é sua grande fã. Lá, encontra uma comunidade de freiras pobres...";

            switch (id)
            {
                case 1:
                    return velozesFuriosos;
                case 2:
                    return UmLugarSilencioso;
                case 3:
                    return OsCroods2_UmaNovaEra;
                case 4:
                    return Sibyl;
                case 5:
                    return OCharlatão;
                case 6:
                    return ABoaEsposa;
                case 7:
                    return UmLugar_Silencioso;
                case 8:
                    return OOficialeoEspião;
                case 9:
                    return Veneza;
                case 10:
                    return MausHábitos;
                default:
                    return "";
            }
        }
        public List<Filmes> GetAll(string Buscar = null, bool ordenar = false)
        {
            if (Buscar != null)
            {
                return getFilme().FindAll(f => f.Nome.ToLower().Contains(Buscar.ToLower()));
            }
            if (ordenar)
            {
                var filmes = getFilme();
                filmes = filmes.OrderBy(f => f.Nome).ToList();
                return filmes;
            }
            return getFilme();
        }
        public bool Create(Filmes filme)
        {
            try
            {
                List<Filmes> filmes = getFilme();
                filme.Id = filmes.Count() + 1;
                filmes.Add(filme);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public Filmes Get(int? Id)
        {
            return getFilme().FirstOrDefault(f => f.Id == Id);
        }
        public bool Update(Filmes filme)
        {
            return true;
        }
        public bool Delete(int? Id)
        {
            return false;
        }

    }
}
