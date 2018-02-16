using CryptoQueryWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoQueryWebAPI.ModelsWithHardCodedData
{
    public class Articles
    {
        private static List<ArticleDto> _articlesDto = new List<ArticleDto>();

        public List<ArticleDto> ArticlesList
        {
            get
            {
                return _articlesDto;
            }
            set
            {
                _articlesDto = value;
            }
        }

        public Articles()
        {
            _articlesDto.AddRange( new List<ArticleDto>() {
                     new ArticleDto()
                     {
                         Author = "Jeff Kauflin ",
                         Complexity = 6,
                         CreatedAt = DateTime.Now.ToLongTimeString(),
                         DateOfPublification = "February 28, 2018",
                         Id = Guid.NewGuid().ToString("N"),
                         Quality = 5,
                         Title = @"
Forbes' First List Of Cryptocurrency's Richest: Meet The Secretive Freaks, Geeks And Visionaries Minting Billions From Bitcoin Mania",
                         Topic = "BitCoin",
                         UpdatedAt = string.Empty,
                         Url = @"https://www.forbes.com/sites/jeffkauflin/2018/02/07/cryptocurrency-richest-people-crypto-bitcoin-ether-xrp/#6bae37772d3e"
                     },

            new ArticleDto()
            {
                Author = "Nolan Bauerle and Peter Ryan",
                Complexity = 9,
                DateOfPublification = "February 7, 2018",
                Id = Guid.NewGuid().ToString("N"),
                Quality = 8,
                Title = "CoinDesk Releases 2018 Blockchain Industry Report",
                Topic = "Ethereum",
                UpdatedAt = string.Empty,
                CreatedAt = DateTime.Now.ToLongTimeString(),
                Url = "https://www.coindesk.com/coindesk-releases-2018-bitcoin-blockchain-industry-report/"
            },

            new ArticleDto()
            {
                Author = "William Suberg",
                Complexity = 8,
                Url = "https://cointelegraph.com/news/mens-new-york-fashion-week-shows-threads-of-crypto-inspiratio",
                CreatedAt = DateTime.Now.ToLongTimeString(),
                UpdatedAt = string.Empty,
                DateOfPublification = "February 8, 2018",
                Id = DateTime.Now.ToLongTimeString(),
                Quality = 9,
                Title = @"Germany’s Blockchain Bundesverband Lobby Group: Government ‘Welcomes Blockchain Industry’",
                Topic = "BlockChain"
            }
                });
        }
    }
}
