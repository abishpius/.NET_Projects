/* Initialize Hero and Monster then have them battle 
until a winner is decided */

int hero = 10;
int monster = 10;

Random random = new Random();
int damage = 0;

while (hero > 0 && monster > 0)
{
    damage = random.Next(1,11);
    monster = monster - damage;
    Console.WriteLine($"Monster was damaged and lost {damage} health and now has {monster} health.");
    if (monster <= 0)
    {
        Console.WriteLine("Hero wins!");
        break;
    }
    damage = random.Next(1,11);
    hero = hero - damage;
    Console.WriteLine($"Hero was damaged and lost {damage} health and now has {hero} health.");
    if (hero <= 0)
    {
        Console.WriteLine("Monster wins!");
        break;
    }
}
