using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace GameProgII_HealthSystemRe_BenF
{
    class Program
    {
        class Health
        {
            public int CurrentHealth { get; private set; }

            public int MaxHealth { get; private set; }

            public void TakeDamage(int amount)
            {

                if (amount < 0)
                {
                    Console.WriteLine("You inputed a negative number!");
                    return;
                }

                else
                {
                    CurrentHealth -= amount;

                    if (CurrentHealth < 0)
                    {
                        CurrentHealth = 0;
                    }
                    return;
                }
            }


            public void Heal(int amount)
            {

                if (amount < 0)
                {
                    Console.WriteLine("You inputed a negative number!");
                    return;
                }

                else if (amount > MaxHealth)
                {
                    CurrentHealth = MaxHealth;

                    if (CurrentHealth > MaxHealth)
                    {
                        CurrentHealth = MaxHealth;
                    }
                    return;
                }
            }

            public void Restore()
            {
                CurrentHealth = MaxHealth;
            }

            public Health(int maxHealth)
            {
                CurrentHealth = maxHealth;
                MaxHealth = maxHealth;

                _maxHealth = MaxHealth;
                _currentHealth = CurrentHealth;
            }

            int _maxHealth;
            public int GetMaxHealth()
            {
                return _maxHealth;
            }


            int _currentHealth;
            public int GetCurrentHealth()
            {
                return _currentHealth;
            }

        }
        class Player
        {
            public float Name { get; set; }

            Health Health;
            Health Shield;

            public void TakeDamage(int amount)
            {
                if (amount < 0)
                {
                    Console.WriteLine("You inputed a negative number!");
                    return;
                }

                Health.TakeDamage(amount);

            }

            public string GetStatusString()
            {
                string healthStatus;

                int health = Health.GetCurrentHealth();

                if (health == 100)
                {
                    healthStatus = "Perfect Healthy";
                    return healthStatus;
                }
                else if (health >= 75)
                {
                    healthStatus = "Healthy";
                    return healthStatus;
                }
                else if (health >= 50)
                {
                    healthStatus = "Hurt";
                    return healthStatus;
                }
                else if (health >= 10)
                {
                    healthStatus = "Badly Hurt";
                    return healthStatus;
                }
                else if (health >= 1)
                {
                    healthStatus = "Immident Danger";
                    return healthStatus;
                }

                else if (health == 0)
                {
                    healthStatus = "Dead";
                    return healthStatus;
                }

                else
                {
                    healthStatus = "what are you?";
                    return healthStatus;
                }
            }
            public Player(string name, int maxHealth, int maxShield)
            {
                _name = name;

                _maxHealth = maxHealth;

                _maxShield = maxShield;
            }

            string _name;

            public string GetName()
            {
                return _name;
            }

            int _maxHealth;

            public int GetMaxHealth()
            {
                return _maxHealth;
            }

            int _maxShield;

            public int GetMaxShield()
            {
                return _maxShield;
            }
        }

        static void Main(string[] args)
        {
            string name = Console.ReadLine();

            Player player = new Player(name, 100, 50);


        }
    }
}
