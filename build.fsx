#r @"packages/build/FAKE/tools/FakeLib.dll"

open Fake

let buildDir = "./build/"

let akkaProject = "src/AkkaPlayground/AkkaPlayground.csproj"

let mode = getBuildParam "mode"

Target "Clean" (fun _ ->
    CleanDirs [buildDir]
)

Target "Build" (fun _ ->
    !! akkaProject
    |> match mode.ToLower() with
       | "release" -> MSBuildRelease buildDir "Build"
       | _ -> MSBuildDebug buildDir "Build"
    |> Log "Build Output:"
)

Target "Default" DoNothing

"Clean"
    ==> "Build"
    ==> "Default"

RunTargetOrDefault "Default"
