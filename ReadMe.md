# Image to shulkers

<h2>Use</h2>

The program takes any type of image as an input and with the help of the config file it outputs a file named ```image.mcfunction``` that is used with the help of a datapack. Because the program itself does not create a minecraft datapack you will need to download a datapack template from the internet and put the file in the functions folder of the datapack.

<br>

```
├── datapack
|  ├── minecraft
|  ├── NAME_OF_DIRECTORY (the template may contain a different name)
|  |  ├── functions
|  |  |  ├── image.mcfunction
|  pack.mcmeta
```

<br>

After you do that you will need to put a file named ```image.json``` file in a different functions directory with the following code but replace the ```NAME_OF_DIRECTORY``` with the corresponding directory name.

<br>

```json
{
    "values": [
        "NAME_OF_DIRECTORY:image"
    ]
}
```

<br>

```
├── datapack
|  ├── minecraft
|  |  ├── tags
|  |  |  ├── functions
|  |  |  ├── image.json
|  ├── name (the template may contain a different name)
|  pack.mcmeta
```

<br>

After you do that you just need to go to you minecraft world with commands enabled and ```/function #minecraft:image``` and you are done !!!! You have successfuly have the original image you used into your minecraft world.

<br>

---

### Notes

<br>

**Special thanks to [majorsopa](https://github.com/majorsopa) for giving me that idea in the first place !**
**Also thanks to [Theodore Tsirpanis](https://github.com/teo-tsirpanis) for suggesting some changes !**