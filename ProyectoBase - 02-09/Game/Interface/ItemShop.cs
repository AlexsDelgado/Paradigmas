
using System;

namespace Game
{
    public class ItemShop : Asset, IInteractable
    {
        public int _cost { get; set; }
        private int _itemId;

        public ItemShop(int cost, int id)
        {
            _cost = cost;
            _itemId = id;
        }
        public int GetId()
        {
            return _itemId;
        }
        public void Interact()
        {
            
            if (GameManager.Instance.coins>_cost)
            {
                GameManager.Instance.coins -= _cost;
                switch (_itemId)
                {
                    case 0:
                        float str =GameManager.Instance.currentPlayer.GetStr();
                        GameManager.Instance.currentPlayer.SetStr(str+5);
                        Engine.Debug($"Player STR: { GameManager.Instance.currentPlayer.GetStr()}");

                        break;

                    case 1:

                        GameManager.Instance.playerArmor += 5;
                        Engine.Debug($"Player Armor: { GameManager.Instance.playerArmor}");
                        break;

                    case 2:
                        float hp = GameManager.Instance.currentPlayer.GetHp();
                        GameManager.Instance.currentPlayer.SetStr(hp + 20);
                        Engine.Debug($"Player HP: { GameManager.Instance.currentPlayer.GetHp()}");
                        break;

                    case 3:
                        break;
                    default:
                        break;
                }
                transform.SetPosition(1000, 1000);
            }
            else
            {
                Console.WriteLine("Faltan Monedas");
            }



        }
    }
}
