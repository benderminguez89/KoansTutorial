let AssertEquality a b = if a<>b then failwith "FAILED!" else printfn "TEST SUCCESS!"

//---------------------------------------------------------------
// Overview
//
// Below is a set of exercises designed to get you familiar 
// with F#. By the time you're done, you'll have a basic 
// understanding of the syntax of F# and learn a little more
// about functional programming in general.
//
// Answering Problems
// 
// This is where the fun begins! Each dashed section contains an 
// example designed to teach you a lesson about the F# language. 
// If you highlight the code in an example and execute it (use 
// Ctrl+Enter or the run button) it will initially fail. Your
// job is to fill in the blanks to make it pass. With each
// passing section, you'll learn more about F#, and add another
// weapon to your F# programming arsenal.
//
// Start by highlighitng the section below and running it. Once
// you see it fail, replace the __ with 2 to make it pass.
//---------------------------------------------------------------

// ---- about asserts -------------------------------------------

let expected_value = 1 + 1
let actual_value = 2

AssertEquality expected_value actual_value
//Easy, right? Try the next one.

//---------------------------------------------------------------
 
// ---- more about asserts --------------------------------------

AssertEquality "foo" "foo"

//---------------------------------------------------------------

//---------------------------------------------------------------



// About Let
//
// The let keyword is one of the most fundamental parts of F#.
// You'll use it in almost every line of F# code you write, so
// let's get to know it well! (no pun intended)
//---------------------------------------------------------------

// ---- let binds a name to a value -----------------------------

let x = 50
        
AssertEquality x 50

    
//---------------------------------------------------------------

// ---- let infers the type of values when it can ---------------

(* In F#, values created with let are inferred to have a type like
   "int" for integer values, "string" for text values, and "bool" 
   for true or false values. *)

let x = 50
let typeOfX = x.GetType()
AssertEquality typeOfX typeof<int>

let y = "a string"
let expectedType = y.GetType()
AssertEquality expectedType typeof<string>

//---------------------------------------------------------------

// ---- you can make the types explicit -------------------------

let (x:int) = 42
let typeOfX = x.GetType()

let y:string = "forty two"
let typeOfY = y.GetType()

AssertEquality typeOfX typeof<int>
AssertEquality typeOfY typeof<string>

(* You don't usually need to provide explicit type annotations 
   types for local varaibles, but type annotations can come in 
   handy in other contexts as you'll see later. *)


//---------------------------------------------------------------

// ---- floats and ints -----------------------------------------

(* Depending on your background, you may be surprised to learn that
    in F#, integers and floating point numbers are different types. 
    In other words, the following is true. *)
let x = 20
let typeOfX = x.GetType()

let y = 20.0
let typeOfY = y.GetType()

//you don't need to modify these
AssertEquality typeOfX typeof<int>
AssertEquality typeOfY typeof<float>

//If you're coming from another .NET language, float is F# slang for
//the double type.
   
//---------------------------------------------------------------

// ---- modifying the value of variables ------------------------

let mutable x = 100
x <- 200

AssertEquality x 200

//////SHADOWING////
//---------------------------------------------------------------

// ---- you can't modify a value if it isn't mutable ------------

let x = 50

//What happens if you try to uncomment and run the following line of code?
//(look at the output in the output window)
//x <- 100

//NOTE: Although you can't modify immutable values, it is 
//      possible to reuse the name of a value in some cases 
//      using "shadowing".
let x = 100
 
AssertEquality x 100

//---------------------------------------------------------------

//---------------------------------------------------------------
// About Functions
//
// Now that you've seen how to bind a name to a value with let,
// you'll learn to use the let keyword to create functions.
//---------------------------------------------------------------

// ---- creating functions with let -----------------------------

(* By default, F# is whitespace sensitive. For functions, this 
   means that the last line of a function is its return value,
   and the body of a function is denoted by indentation. *)

let add x y =
    x + y

let result1 = add 2 2
let result2 = add 5 2

AssertEquality result1 4
AssertEquality result2 7


//---------------------------------------------------------------

// ---- nesting functions ---------------------------------------

let quadruple x =    
    let double x =
        x * 2

    double(double(x))

let result = quadruple 4
AssertEquality result 16


//---------------------------------------------------------------

// ---- adding type annotations ---------------------------------

(* Sometimes you need to help F#'s type inference system out with
   an explicit type annotation *)

let sayItLikeAnAuctioneer (text:string) =
    text.Replace(" ", "")

let auctioneered = sayItLikeAnAuctioneer "going once going twice sold to the lady in red"
AssertEquality auctioneered "goingoncegoingtwicesoldtotheladyinred"

//TRY IT: What happens if you remove the type annotation on text?
//---------------------------------------------------------------

// ---- variables in the parent scope can be accessed -----------

let suffix = "!!!"

let caffinate (text:string) =
    let exclaimed = text + suffix
    let yelled = exclaimed.ToUpper()
    yelled.Trim()

let caffinatedReply = caffinate "hello there"

AssertEquality caffinatedReply "HELLO THERE!!!"

(* NOTE: Accessing the suffix variable in the nested caffinate function 
         is known as a closure. 
         
         See http://en.wikipedia.org/wiki/Closure_(computer_science) 
         for more about about closure. *)

//---------------------------------------------------------------

//---------------------------------------------------------------
// About the Order of Evaluation
//
// Sometimes you'll need to be explicit about the order in which
// functions are evaluated. F# offers a couple mechanisms for
// doing this.
//---------------------------------------------------------------

// ---- using parenthesis to control the order of operation -----

let add x y =
    x + y

let result = add (add 5 8) (add 1 1)

AssertEquality result 15
(* TRY IT: What happens if you remove the parensthesis?*)
//---------------------------------------------------------------

// ---- you can create arrays with comprehensions ---------------

let numbers = 
    [| for i in 0..10 do 
           if i % 2 = 0 then yield i |]

AssertEquality numbers [|0;2;4;6;8;10|]

//---------------------------------------------------------------

// ---- you can also perform operations on arrays ---------------

let cube x =
    x * x * x

let original = [| 0..5 |]
let result = Array.map cube original

AssertEquality original [|0;1;2;3;4;5|]
AssertEquality result [|0;1;8;27;64;125|]

(* See more Array methods at
   http://msdn.microsoft.com/en-us/library/ee370273.aspx *)

//---------------------------------------------------------------
// Looping
//
// While it's more common in F# to use the Seq, List, or Array
// modules to perform looping operations, you can still fall 
// back on traditional imperative looping techniques that you may 
// be more familiar with.
//---------------------------------------------------------------

// ---- looping over a list -------------------------------------

let values = [0..10]

let mutable sum = 0
for value in values do
    sum <- sum + value

AssertEquality sum 55

//---------------------------------------------------------------

// ---- looping with expressions --------------------------------

let mutable sum = 0

for i = 1 to 5 do
    sum <- sum + i

AssertEquality sum 15

//---------------------------------------------------------------

// ---- looping with while --------------------------------------

let mutable sum = 1

while sum < 10 do
    sum <- sum + sum

AssertEquality sum 16

(* NOTE: While these looping constructs can come in handy from time to time,
         it's often better to use a more functional approach for looping
         such as the functions you learned about in the List module. *)

//---------------------------------------------------------------

//---------------------------------------------------------------
// More About Funtions
//
// You've already learned a little about funcitons in F#, but
// since F# is a functional language, there are more tricks
// to learn!
//---------------------------------------------------------------

// ---- defining lambdas ----------------------------------------

let colors = ["maize"; "blue"]

let echo = 
    colors
    |> List.map (fun x -> x + " " + x)

AssertEquality echo ["maize maize"; "blue blue"]

(* The fun keyword allows you to create a function inline without giving
   it a name. These functions are known as anonymous functions, lambdas,
   or lambda functions. *)

//---------------------------------------------------------------

// ---- functions that return functions  ------------------------

(* A neat functional programming trick is to create functions that 
   return other functions. This leads to some interesting behaviors. *)
let add x =
    (fun y -> x + y)

(* F#'s lightweight syntax allows you to call both functions as if there
   was only one *)
let simpleResult = add 2 4
AssertEquality simpleResult 6

(* ...but you can also pass only one argument at a time to create
   residual functions. This technique is known as partial appliction. *)
let addTen = add 10
let fancyResult = addTen 14

AssertEquality fancyResult 24

//NOTE: Functions written in this style are said to be curried.

//---------------------------------------------------------------

// ---- automatic currying --------------------------------------

(* The above technique is common enough that F# actually supports this
   by default. In other words, functions are automatically curried. *)
let add x y = 
    x + y

let addSeven = add 7
let unluckyNumber = addSeven 6
let luckyNumber = addSeven 0

AssertEquality unluckyNumber 13
AssertEquality luckyNumber 7

//---------------------------------------------------------------

// ---- non curried functions -----------------------------------

(* You should stick to the auto-curried function syntax most of the 
   time. However, you can also write functions in an uncurried form to
   make them easier to use from languages like C# where currying is not 
   as commonly used. *)

let add(x, y) =
    x + y

(* NOTE: "add 5" will not compile now. You have to pass both arguments 
         at once *)

let result = add(5, 40)

AssertEquality result 45

(* THINK ABOUT IT: You learned earlier that functions with multiple 
                   return values are really just functions that return
                   tuples. Do functions defined in the uncurried form
                   really accept more than one argument at a time? *)

//---------------------------------------------------------------