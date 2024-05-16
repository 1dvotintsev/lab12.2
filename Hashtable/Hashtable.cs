using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Hashtable
{
    public class Hashtable<TKey, TValue>
    {
        public Point<TKey, TValue>[] table;

        int count = 0;
        public double fillRatio;
        public int Capacity => table.Length;
        public int Count
        {  
            get { return count; } 
            set { count = value; }
        }
         

        public Hashtable(int size = 10, double fillRato = 0.72) 
        {
            if (size < 0)
                throw new Exception("Размер таблицы < 0 невозможен");
            table = new Point<TKey, TValue>[size];
            
            fillRatio = fillRato;
        }

        public int GetIndex(TKey data)
        {
            if (data != null)
            {
                return Math.Abs(data.GetHashCode()) % Capacity;
            }
            else
                throw new Exception("Не введен ключ");
        }

        public Hashtable<TKey, TValue> AddItem(TKey key, TValue value)
        {
            if (FindItem(key) == -1)
            {
                int number = Count+1;
                if ((double)number  / Capacity - fillRatio > 0 )
                {
                    Hashtable<TKey, TValue> temp = new Hashtable<TKey, TValue>(this.Capacity*2);
                    
                    for (int i = 0; i < table.Length; i++)
                    {
                        if (table[i] != null && table[i].Key != null && table[i].Value != null)
                        {
                            temp.table = temp.AddData(this.table[i].Key, this.table[i].Value);
                        }
                        else
                            temp.table[i] = null;
                    }

                    temp.table = temp.AddData(key,value);
                    //temp.AddData(key ,value);
                    return temp;

                }
                this.table= this.AddData(key, value);
                return this;
            }
            else
            {
                throw new Exception("Элемент с таким ключем уже есть");
            }
        }

        public Point<TKey, TValue>[] AddData(TKey key, TValue value)
        {
            if (value == null || key == null) return this.table;

            int index = GetIndex(key);
            int current = index;

            if (table[index] != null)
            {
                while (current < table.Length || (((table[current] != null|| table[current].Key != null)) && !table[current].isDeleted))
                    current++;

                if (current == table.Length)
                {
                    current = 0;
                    while (current < index || (((table[current] != null || table[current].Key != null)) && !table[current].isDeleted))
                        current++;

                    if (current == index)
                        throw new Exception("Нет места в таблице");
                }
            }

            table[current] = new Point<TKey,TValue>(key, value);
            count++;
            return this.table;
        }

        public int FindItem(TKey key)
        {
            int index = GetIndex(key);

            if (table[index] != null)
            {
                if (table[index].Key == null && !table[index].isDeleted) return -1;   //случай удалений
                if (table[index] != null && table[index].Key != null && table[index].Key.Equals(key)) return index;

                else
                {
                    int current = index;

                    while (current < table.Length)
                    {
                        if (table[current] != null && table[index].Key != null &&  table[current].Key.Equals(key)) return current;
                        current++;
                    }

                    current = 0;
                    while (current < index)
                    {
                        if (table[current] != null && table[current].Key != null && table[current].Key.Equals(key)) return current;  //вторая проверка было index
                        current++;
                    }
                }
                return -1;
            }
            else
                return -1;
        }

        public Hashtable<TKey, TValue> Delete(TKey key)
        {
            int index = GetIndex(key);

            if (table[index] == null || (table[index].Key == null && !table[index].isDeleted))
            {
                throw new Exception("Нет такого элемента");
            }

            if (table[index] != null && table[index].Key != null && table[index].Key.Equals(key))
            {
                table[index] = table[index].Remove();
                Count--;
                return this;
            }

            else
            {
                int current = index;

                while (current < table.Length)
                {
                    if (table[current] != null && table[index].Key != null && table[current].Key.Equals(key))
                    {
                        table[current] = table[current].Remove();
                        Count--;
                        return this;
                    }
                    current++;
                }

                current = 0;
                while (current < index)
                {
                    if (table[current] != null && table[index].Key != null && table[current].Key.Equals(key))
                    {
                        table[current] = table[current].Remove();
                        Count--;
                        return this;
                    }
                    current++;
                }
            }
            
            throw new Exception("Нет такого элемента");
        }

        public Hashtable<TKey, TValue> Clear()
        {
            for(int i = 0; i < table.Length; i++)
            {
                table[i] = null;               
            }
            Count = 0;
            return this;
        }

        public override string ToString()
        {
            string result = "";

            if (table == null || Count == 0)
            {
                return "Таблица пуста";
            }
            else
            {
                int current = 0;

                for (int i = 0; i < this.Capacity; i++)
                {

                    result += $"\nЯчейка {i}:\n";
                    if (this.table[i] != null && this.table[i].Value != null)
                    {
                        result+=$"{ this.table[i].Value.ToString()}\n";
                    }
                }
                return result;
            }
        }       
    }
}
