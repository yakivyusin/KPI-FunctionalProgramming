module Program

open Elmish
open Elmish.React

(*
    Збираємо окремі складові разом та запускаємо, передавши id елемента на сторінці.
*)
Program.mkSimple CounterLogic.init CounterLogic.update CounterView1.view
|> Program.withReactSynchronous "elmish-app"
|> Program.run
