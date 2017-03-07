#r @"packages/build/FAKE/tools/FakeLib.dll"

open Fake

let buildDir = "./build/"

let akkaProject = "src/AkkaPlayground/AkkaPlayground.csproj"

Target "Clean" (fun _ ->
    CleanDirs [buildDir]
)

Target "Default" DoNothing

"Clean"
    ==> "Default"

RunTargetOrDefault "Default"
