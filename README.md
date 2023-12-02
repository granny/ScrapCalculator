# ScrapCalculator

Highlights scrap in a different color to indicate what scrap you can sell to meet quota. Only works when in the ship.

## Installation

* Install [BepInEx](https://thunderstore.io/c/lethal-company/p/BepInEx/BepInExPack/)
* Unzip this mod into your `Lethal Company/BepInEx` folder

Or use the [r2modman](https://github.com/ebkr/r2modmanPlus) mod manager to install everything for you.

## Compiling

Prerequisites: read the [Lethal Company Modding Guide](https://lethal.wiki/)

1. Download the [APublicizer](https://github.com/iRebbok/APublicizer) assembly publicizer
1. Run the assembly publicizer on the `Assembly-CSharp.dll` file in `steamapps/common/Lethal Company/Lethal Company_Data/Managed/`
    ```shell
   $ ./APublicizer <path_to_assembly-csharp_dll_file>
    ```
   This will create a `Assembly-CSharp-Publicized.dll` file
1. Change the path for `Assembly-CSharp-Publicized.dll`, `UnityEngine.dll` and `Unity.Netcode.Runtime.dll` to the one available in `steamapps/common/Lethal Company/Lethal Company_Data/Managed/`
1. run `dotnet build`

took inspiration from [ShipLoot](https://github.com/tinyhoot/ShipLoot/).
