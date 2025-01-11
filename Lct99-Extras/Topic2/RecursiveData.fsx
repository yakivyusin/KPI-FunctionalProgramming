(* Краще дивитися після: лекція 5 *)

(*
    Крім рекурсивних функцій, ми можемо використовувати ключове слово rec для того,
    щоб скомпілювати створення значень рекурсивних типів.
*)
type TreeNode = { Parent: TreeNode; Value: int }

(*
    Корінь дерева посилається на самого себе у якості батька, але без rec ми це не скомпілюємо.
*)
let rec root = { Parent = root; Value = 10 }
let child = { Parent = root; Value = 20 }
let child2 = { Parent = child; Value = 30 }

printfn "%A" child2
