open System

let rec proiz n=
   match n with
   |0->1
   |_-> (n%10)*(proiz(n/10))

let mult n=
   let rec MultCifr n curMult=
       match n with
       |0-> curMult
       |_->
           let n_new=n/10
           let cifr=n%10
           let new_mult=curMult*cifr
           MultCifr n_new new_mult
   MultCifr n 1

let rec min_cifr n=
   match n with
   |_ when n<10 -> n
   |_ -> min (n%10) (min_cifr (n/10))

let min_min n=
   let rec minimum n min=
       match n with
       |_ when n=0->min
       |_ ->
           let newn=n/10
           let newmin=
               if n%10<min then n%10
               else min
           minimum newn newmin
   minimum n 9

let rec max_cifr n=
   match n with
   |_ when n<10 -> n
   |_ -> max (n%10) (max_cifr (n/10))

let max_max n=
   let rec maximum n max=
       match n with
       |_ when n<10->max
       |_ ->
           let newn=n/10
           let newmax=
               if n%10>max then n%10
               else max
           maximum newn newmax
   maximum n 0

[<EntryPoint>]
let main argv = 
   Console.WriteLine("Введите число: ")
   let t=Convert.ToInt32(Console.ReadLine())
   Console.WriteLine("Произведение цифр (рекурсия вверх): ")
   Console.WriteLine(proiz t)
   Console.WriteLine("Произведение цифр (рекурсия хвостовая): ")
   Console.WriteLine(mult t)
   Console.WriteLine("Минимальная цифра числа (рекурсия вверх): ")
   Console.WriteLine(min_cifr t)
   Console.WriteLine("Минимальная цифра числа (рекурсия хвостовая): ")
   Console.WriteLine(min_min t)
   Console.WriteLine("Максимальная цифра числа (рекурсия вверх): ")
   Console.WriteLine(max_cifr t)
   Console.WriteLine("Максимальная цифра числа (рекурсия хвостовая): ",max_max t)
   Console.WriteLine(max_max t)
   0
