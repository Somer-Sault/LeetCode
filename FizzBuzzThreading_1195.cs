using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ConsoleApp1
{
  // LeetCode FizzBuzzThreading_1195 - elegant solution

  class FizzBuzz//  
  {

    int n;

    Barrier b = new Barrier(4);

    void spin() => b.SignalAndWait();

    int step { get => (int)b.CurrentPhaseNumber; } // used as i
    bool done { get => (step == n); }

    bool divisibleBy(int m) => (step % m == 0);

    public FizzBuzz(int n)
    {
      this.n = n;
    }

    void work(Func<bool> predicate, Action<int> action)
    {
      do { spin(); if (predicate()) action(step); } while (!done);
    }

    public void Fizz(Action printFizz) => work(() => divisibleBy(3) && !divisibleBy(5), x => printFizz());
    public void Buzz(Action printBuzz) => work(() => !divisibleBy(3) && divisibleBy(5), (x) => printBuzz());
    public void Fizzbuzz(Action printFizzBuzz) => work(() => divisibleBy(3) && divisibleBy(5), (x) => printFizzBuzz());
    public void Number(Action<int> printNumber) => work(() => !divisibleBy(3) && !divisibleBy(5), (x) => printNumber(x));
  }
}
