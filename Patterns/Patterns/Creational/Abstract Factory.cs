using System;

namespace Patterns.Creational {
    class Abstract_Factory {
        public void Run() {
            Hero elf = new Hero(new ElfFactory());
            elf.Run();
            elf.Attack();

            Hero warrior = new Hero(new WarriorFactory());
            warrior.Run();
            warrior.Attack();

        }

    }

    abstract class Weapon {
        public abstract void Hit();
    }
    abstract class Movement {
        public abstract void Move();
    }

    class Arbalet : Weapon {
        public override void Hit() {
            Console.WriteLine("Arbalet headshot");
        }
    }

    class Sword : Weapon {
        public override void Hit() {
            Console.WriteLine("Sword beat");
        }
    }

    class Fly : Movement {
        public override void Move() {
            Console.WriteLine("I'm flying");
        }
    }

    class Run : Movement {
        public override void Move() {
            Console.WriteLine("I'm running");
        }
    }
    abstract class HeroFactory {
        public abstract Movement CreateMovement();
        public abstract Weapon CreateWeapon();
    }

    class ElfFactory : HeroFactory {
        public override Movement CreateMovement() {
            return new Fly();
        }
        public override Weapon CreateWeapon() {
            return new Arbalet();
        }
    }

    class WarriorFactory : HeroFactory {
        public override Movement CreateMovement() {
            return new Run();    
        }
        public override Weapon CreateWeapon() {
            return new Sword();
        }
    }

    class Hero {
        private Weapon weapon;
        private Movement movement;
        public Hero(HeroFactory factory) {
            weapon = factory.CreateWeapon();
            movement = factory.CreateMovement();
        }
        public void Run() {
            movement.Move();
        }
        public void Attack() {
            weapon.Hit();
        }

    }


}