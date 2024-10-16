﻿// See https://aka.ms/new-console-template for more information


using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Markup;

Console.WriteLine("-------Arrays--------------------------------------");

int[] MyArray = {1,2,3,4,5,6,7,8,9}; //array of int (can be of any type) as data structure
for (int i = 0; i < MyArray.Length; i++)
{
    Console.WriteLine(MyArray[i]);
}

Console.WriteLine("--------Structures-------------------------------------");

MyStruct st = new();
st.Name = "Structure";
Console.WriteLine(st.Name);

Console.WriteLine("---------Stack------------------------------------");

Stack<int> NewStack;
NewStack = new();
NewStack.Push(1);
NewStack.Push(2);
NewStack.Push(3);
NewStack.Push(4);
Console.WriteLine("Popped value was " + NewStack.Pop()/*remove value 4*/);

Console.WriteLine("--------List-------------------------------------");

List<int> NewList;//List that store data for integer values
NewList = [1,2,3];

Console.WriteLine(NewList.Remove(1)/*removes value 1*/ + " as value 1 successfully removed");

Console.WriteLine("--------LinkedList-------------------------------------");

LinkedList<int> NewLinkedList;

LinkedListNode<int> newLinkedListNode;// nodes for linked list
NewLinkedList = new();// linked list creation
NewLinkedList.AddFirst(1);
NewLinkedList.AddFirst(2);
NewLinkedList.AddFirst(3);
NewLinkedList.AddFirst(4);
NewLinkedList.AddFirst(6);
newLinkedListNode = new(5);
NewLinkedList.AddAfter(NewLinkedList.Find(6), newLinkedListNode);

foreach (int vals in NewLinkedList) {
    Console.WriteLine(vals);
}

Console.WriteLine("--------Dictionary-------------------------------------");
Dictionary<string, int> NewDictionary; //string keys; int values
NewDictionary = new()
{
    {"a" , 1},
    {"b" , 2},
    {"c" , 3},
    {"d" , 4},
    {"e" , 5},

};

Console.WriteLine("Value at a is " + NewDictionary["a"]);

Console.WriteLine("--------Queue-------------------------------------");

Queue<int> NewQueue;
NewQueue = new();
NewQueue.Enqueue(1);
NewQueue.Enqueue(2);
NewQueue.Enqueue(2);
NewQueue.Enqueue(3);
Console.WriteLine("Dequeuing value " + NewQueue.Dequeue()/*Removing top Value(1)*/);





struct MyStruct
{
    public string Name;

};