using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Behavioral {
    class Observer {
        public void Run() {
            Stock stock = new Stock();
            Bank bank = new Bank("Thief bank", stock);
            Broker broker = new Broker("Some broker", stock);
            stock.Market();
            broker.StopTrade();
            stock.Market();

        }
    }

    interface IObserver {
        void Update(Object obj);
    }

    interface IObservable {
        void RegistObserver(IObserver o);
        void RemoveObserver(IObserver o);
        void NotifyObserver();
    }

    class Stock : IObservable {
        StockInfo sInfo;

        List<IObserver> observers;
        public Stock() {
            observers = new List<IObserver>();
            sInfo = new StockInfo();
        }
        public void RegistObserver(IObserver o) {
            observers.Add(o);
        }
        public void RemoveObserver(IObserver o) {
            observers.Remove(o);
        }
        public void NotifyObserver() {
            foreach(IObserver o in observers) {
                o.Update(sInfo);
            }
        }

        public void Market() {
            Random rnd = new Random();
            sInfo.USD = rnd.Next(20, 40);
            sInfo.Euro = rnd.Next(30, 50);
            NotifyObserver();
        }
    }

    class StockInfo {
        public int USD { get; set; }
        public int Euro { get; set; }
    }

    class Broker : IObserver {
        public string Name;
        IObservable stock;

        public Broker(string name, IObservable o) {
            Name = name;
            stock = o;
            stock.RegistObserver(this);
        }
        public void Update(Object o) {
            StockInfo sInfo = (StockInfo)o;
            if(sInfo.USD > 30) {
                Console.WriteLine("Broker {0} is selling dollars; Exchange rates: {1}", Name, sInfo.USD);
            } else {
                Console.WriteLine("Broker {0} is buying dollars; Exchange rates: {1}", Name, sInfo.USD);
            }
        }

        public void StopTrade() {
            stock.RemoveObserver(this);
            stock = null;
        }
    }

    class Bank : IObserver {
        public string Name;
        IObservable stock;

        public Bank(string name, IObservable o) {
            Name = name;
            stock = o;
            stock.RegistObserver(this);
        }
        public void Update(Object o) {
            StockInfo sInfo = (StockInfo)o;
            if (sInfo.USD > 30) {
                Console.WriteLine("Broker {0} is selling euro; Exchange rates: {1}", Name, sInfo.Euro);
            } else {
                Console.WriteLine("Broker {0} is buying euro; Exchange rates: {1}", Name, sInfo.Euro);
            }
        }
    }
}
