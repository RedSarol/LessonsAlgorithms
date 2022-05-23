using System;
using System.Collections.Generic;
using System.Text;

namespace LessonAlgorithms
{
    public class Node_lessons_2
    {
        public int ValueNode { get; set; }
        public Node_lessons_2 NextNode { get; set; }
        public Node_lessons_2 PrevNode { get; set; }
    }

    public interface ILinKedList
    {
        public static Node_lessons_2 head; //начальный элемент
        public static Node_lessons_2 tail; //новый элемент


        public static int GetCount()
        {
            Node_lessons_2 target = head;
            int count = 0;
            while(target != null)
            {
                
                if(target.PrevNode != null)
                    Console.WriteLine($"Нод №{count} значение {target.ValueNode} предыдущий {target.PrevNode.ValueNode}");
                else
                    Console.WriteLine($"Нод №{count} значение {target.ValueNode}");
                target = target.NextNode;
                count++;
            }
            Console.WriteLine($"всего Нодов {count} \n");
            return count;
        }

        public static void AddNode(int value) //добавляем ноды
        {
            Node_lessons_2 NewNode = new Node_lessons_2();
            NewNode.ValueNode = value;

            if(head == null)
            {
                head = NewNode;
                return;
            } 
            if(tail == null)
            {
                tail = NewNode; 
                head.NextNode = tail; //подсказываем новый нод
                tail.PrevNode = head; //подсказываем предыдущий нод
            }
            else
            {
                NewNode.PrevNode = tail; //подсказываем предыдущий нод
                tail.NextNode = NewNode; //подсказываем новый нод
                tail = NewNode; //объявляем головный новый нод
            }
        }

        public static void AddNodeAfter(Node_lessons_2 targetNode, int value) //добавляем новый нод
        {
            Node_lessons_2 NewNode = new Node_lessons_2();
            NewNode.ValueNode = value;

            if (targetNode.NextNode == null)
            {
                targetNode.NextNode = NewNode;
                NewNode.PrevNode = targetNode;
            } else
            {
                //подсказываем новому ноду
                NewNode.PrevNode = targetNode; //предыдущий нод
                NewNode.NextNode = targetNode.NextNode; //следующий нод

                targetNode.NextNode.PrevNode = NewNode; //изначальному ноду что теперь после него другой новый нод
                targetNode.NextNode = NewNode; //бывшиму ближайшему ноду подсказываем что межжду ним и изначальным вклинился новый нод
            }
            GetCount();
        }

        public static void RemoveNode(Node_lessons_2 targetNode) //удаляем указывая нод
        {
            //выполняем этот сценарий если нет 3 нода
            if (targetNode.NextNode.NextNode == null)
            {

                targetNode.NextNode = null; //удаляем информация о 2 ноде
                //тем самым сборщик муссора удалит 2 нод 
            }
            else
            {
                //подсказываем 
                targetNode.NextNode.NextNode.PrevNode = targetNode; //3 ссылаться на первый
                targetNode.NextNode = targetNode.NextNode.NextNode; //1 ссылаться на 3
            }

            GetCount();
        }

        public static void RemoveNode(int value) //удаляем по номеру
        {
            int count = 0;
            Node_lessons_2 target = head;

            while (ILinKedList.head != null)
            {
                target = target.NextNode;

                if (count == value)
                {
                    
                    if (value == 0) //на случай если надо удалить начальный
                    {
                        head = target;
                        GetCount();
                        return;
                    }
                    if (target.NextNode == null)
                    {
                        target.PrevNode.NextNode = null; //обращаемся к предыдущему ноду и забываем следующий его нод
                        GetCount();
                        return;
                    }
                    else
                    {
                        //подсказываем
                        target.NextNode.PrevNode = target.PrevNode; //след от удаляемого ссылаться на предыдущей до удаляемого
                        target.PrevNode.NextNode = target.NextNode; //пред ноду подсказываем новый ближайший
                        GetCount();
                        return;
                    }
                }
                count++;
            }  
        }

        public static Node_lessons_2 FindNode (int searchValue)
        {
           
            Node_lessons_2 target = head;

            while(target.NextNode != null)
            {
                if (target.ValueNode == searchValue)
                    break; //прерываем цикл 
                target = target.NextNode;
            }
            return target;
        }
    }
}
