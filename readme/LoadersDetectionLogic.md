## Особенности обнаружения заргузчика

Внутри схемы загружаемых модификаций будет содержаться например следующее:
```xml
<?xml charset="utf-8"?>
<mods>
	<!-- Данные загрузчика -->
	<loader>22</loader>

	<!-- Данные архива игры -->
	<version>1.20.4</version>

	<!-- Данные загружаемых архивов -->
	<mod>C:\mods\impressivecaves-neoforge.jar</mod>
	<mod>C:\mods\terralith-forge.jar</mod>
	<!-- и так далее -->
<mods>
```

Для определения загрузчика были зарезервированны целые числа
Модификации родителя-загрузчика тоже используют резервированные числа
```
[curse]
1 - fabric-based configuration
2 - forge-based configuration

[more]
1 - fabric
11 - quilt (fabric based .json config)
2 - forge
22 - neo-forge (forge based .toml config)
```

