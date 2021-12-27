using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Lab8
{
    public class Color
    {
        public void Red()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
        }
        public void Gray()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        public void Green()
        {
            Console.ForegroundColor = ConsoleColor.Green;

        }
        public void Cyan()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;

        }
        public void DarkMagenta()
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;

        }
        public void DarkCyan()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;

        }
    }
    public class Node<T>
    {
        public Node(T data)
        {
            Data = data;
        }
        public Node(T data, Node<T> next)
        {
            Data = data;
            Next = next;
        }
        public T Data { get; set; }
        public Node<T> Next { get; set; }
        public Node<T> SetNextNode(Node<T> node) => Next = node;

    }

    public class Owner
    {
        private string _name;
        private string _organization;
        private static int Id;

        public Owner(string name, string organization)
        {
            this._name = name;
            this._organization = organization;
            Id++;
        }
        public void Print()
        {
            Console.WriteLine($"ID: {Id}\n" +
                $"Name: {_name}\n" +
                $"Organization: {_organization}");
        }
    }

    public class Date
    {
        private DateTime _time;

        public Date()
        {
            _time = DateTime.Now;
        }

        public void ShowDate()
        {
            Console.WriteLine(_time + "\n");
        }
    }

    public class CollectionType<T> : IGen<T> where T : class
    {
        Node<T> head;
        Node<T> tail;
        int count;

        public Node<T> GetHead() => head;

        public T this[int index]
        {
            get
            {
                if (index > count - 1 || index < 0) throw new WrongIndexException("ERROR: индекс");

                Node<T> temp = head;
                for (int i = 0; i < index; i++)
                {
                    temp = temp.Next;
                }

                return temp.Data;
            }
            set
            {
                if (index > count - 1 || index < 0) throw new WrongIndexException("ERROR: индекс");

                Node<T> temp = head;
                for (int i = 0; i < index; i++)
                {
                    temp = temp.Next;
                }

                temp.Data = value;
            }
        }

        public void Add(T item)         // Добавление элемента
        {
            Node<T> node = new Node<T>(item);

            if (head == null)
                head = node;
            else
                tail.Next = node;
            tail = node;

            count++;
        }

        public void ShowInfo()          // Вывод списка
        {
            Node<T> node = head;
            while (node.Next != null)
            {
                Console.Write(node.Data + " --> ");
                node = node.Next;
            }
            Console.WriteLine(node.Data + "\n");
        }

        public bool Remove(T item)      // Удаление по элементу
        {
            Node<T> current = head;
            Node<T> previous = null;

            while (current != null)
            {
                if (current.Data.Equals(item))
                {
                    // Если узел в середине или в конце
                    if (previous != null)
                    {
                        // убираем узел current, теперь previous ссылается не на current, а на current.Next
                        previous.Next = current.Next;
                        // Если current.Next не установлен, значит узел последний,
                        // изменяем переменную tail
                        if (current.Next == null)
                            tail = previous;
                    }
                    else
                    {
                        // если удаляется первый элемент
                        // переустанавливаем значение head
                        head = head.Next;
                        // если после удаления список пуст, сбрасываем tail
                        if (head == null)
                            tail = null;
                    }
                    count--;
                    return true;
                }
                previous = current;
                current = current.Next;
            }
            return false;
        }

        public void Remove(int index)   // Удаление по индексу 
        {
            if (count == 0)
            {
                Console.WriteLine("Список пуст!");
            }
            if (count == 1)
            {
                head = null;
            }
            if (index == 1)
            {
                Console.WriteLine($"Узел {head.Data} удалён!");
                head = head.Next;
                return;
            }

            Node<T> node = head;
            Node<T> nextNode = head.Next;

            for (int i = 0; i < index - 2; i++)
            {
                node = node.Next;
                nextNode = nextNode.Next;
            }
            Console.WriteLine($"Узел {nextNode.Data} удалён!");
            node.SetNextNode(nextNode.Next);
        }

        public bool Contains(T data)    // Проверка на наличие 
        {
            Node<T> current = head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                    return true;
                current = current.Next;
            }
            return false;
        }

        public override string ToString()
        {
            var res = "";
            for (Node<T> pA = head; pA != null; pA = pA.Next)
            {
                res += pA.Data + " ";
            }
            return res;
        }

        #region Перегрузки

        public static CollectionType<T> operator +(CollectionType<T> A, CollectionType<T> B)
        {
            CollectionType<T> list = new CollectionType<T>();

            for (Node<T> p = A.head; p != null; p = p.Next)
                list.Add(p.Data);
            for (Node<T> p = B.head; p != null; p = p.Next)
                list.Add(p.Data);
            return list;
        }

        public static CollectionType<string> operator !(CollectionType<T> A)
        {
            string test = A.ToString();
            var strArr = test.Split(' ');
            string[] strArr2 = new string[strArr.Length - 1];
            Array.Copy(strArr, strArr2, strArr.Length - 1);
            CollectionType<string> list0 = new CollectionType<string>();
            for (int i = strArr2.Length - 1; i > -1; i--)
            {

                string temp = strArr2[i];
                //strArr2[i] = null;
                list0.Add(temp);
            }
            return list0;
        }

        public static CollectionType<T> operator --(CollectionType<T> A)
        {
            A.Remove(1);
            return A;
        }

        public static bool operator !=(CollectionType<T> A, CollectionType<T> B)
        {
            return A.ToString() != B.ToString();
        }
        public static bool operator ==(CollectionType<T> A, CollectionType<T> B)
        {
            return A.ToString() == B.ToString();
        }

        public static bool operator true(CollectionType<T> A)
        {
            return A.head == null;
        }
        public static bool operator false(CollectionType<T> A)
        {
            return A.head != null;
        }
        #endregion

        public class Owner
        {
            string id;
            string name;
            string edition;

            public Owner(string _ID, string _NAME, string _EDITION)
            {
                id = _ID;
                name = _NAME;
                edition = _EDITION;
            }
        }
        public class Date
        {
            DateTime time = new DateTime();

            public DateTime Time { get { return time; } set { this.time = value; } }
            public Date(DateTime time)
            {
                if (time != null)

                    this.time = time;
                else
                    this.time = DateTime.Now;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Color color = new Color();
                color.Gray();
                Owner own = new Owner("Настюшка", "БГТУ");
                own.Print();

                Date d = new Date();
                d.ShowDate();

                color.Cyan();
                CollectionType<string> list1 = new CollectionType<string>();
                Console.Write("--------1-й список--------\n ");
                list1.Add("cucumber");
                list1.Add("potato");
                list1.Add("tomato");
                list1.Add("pumpking");
                list1.ShowInfo();

                color.DarkCyan();
                CollectionType<string> list2 = new CollectionType<string>();
                Console.Write("--------2-й список--------\n ");
                list2.Add("apple");
                list2.Add("orange");
                list2.Add("limon");
                list2.Add("banana");
                list2.ShowInfo();

                color.DarkMagenta();
                CollectionType<string> list12 = new CollectionType<string>();
                Console.Write("\nОбъединение 1 и 2 списков: ");
                list12 = list1 + list2;
                list12.ShowInfo();

                color.Gray();
                Console.WriteLine("\nУдаление первого элемента (через перегрузку) и 6-ой выбором:");
                --list12;
                list12.Remove("orange");
                list12.ShowInfo();


                color.Green();
                if (list1 == list2)
                {
                    Console.WriteLine("\nРавенство 1 и 2 списков:\n------Списки равны------");
                    color.Red();
                }
                else if (list1 != list2) Console.WriteLine("\nРавенство 1 и 2 списков:\n------Списки не равны------");

                CollectionType<string> list11 = new CollectionType<string>();
                Console.Write("Список для сравнения с 1-ым: ");
                list11.Add("cucumber");
                list11.Add("potato");
                list11.Add("tomato");
                list11.Add("pumpking");
                list11.ShowInfo();
                color.Green();
                if (list1 == list11) Console.WriteLine("Равенство 1 и идентичного ему списков:\n------Списки равны------"); else if (list1 != list11) Console.WriteLine("\nРавенство 1 и 2 списков:\n------Списки не равны------");

                color.Red();
                CollectionType<string> emptyList = new CollectionType<string>();
                if (emptyList)
                    Console.WriteLine("\nПустой список!\n");

                color.Cyan();
                CollectionType<string> list3 = new CollectionType<string>();
                Console.Write("--------3-й список--------\n ");
                list3.Add("Кто");
                list3.Add("вкрал");
                list3.Add("мои");
                list3.Add("37-е");
                list3.Add("тапки?");
                list3.ShowInfo();

                Console.WriteLine($"Общая длина элементов списка:{list3.Sum()}");
                Console.WriteLine($"Разница между длинами максимальной и минимальной строк: {list3.Difference()}");
                Console.WriteLine($"В списке {list3.CountOfS()} элементов(a)");
                Console.WriteLine($"Последняя цифра в списке {list3.LastNumb()} \n");

                INfile.WriteToFile(list1);
                color.DarkMagenta();

                //CollectionType<string> FromFile = new CollectionType<string>();
                //FromFile.Add("WORD1");
                //INfile.ReadFromFile(ref FromFile);
                //FromFile.ShowInfo();
                //bool b = FromFile.Contains("WORD1");
                //Console.WriteLine(b);

                CollectionType<Question> question = new CollectionType<Question>();
                question.Add(new Test());
                question.Add(new Exam());
                question.ShowInfo();
                color.Red();
            }
            catch (WrongIndexException ex) { Console.WriteLine(ex); }
            catch (WrongElementException ex) { Console.WriteLine(ex); }
            catch { Console.WriteLine("Возникла ошибка"); }
            finally { Console.WriteLine("FINALLY:That's all.\n"); }

            Console.ReadKey();
            ;
        }
    }
}