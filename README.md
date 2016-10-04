# IFF-ILBM-Parser

The library parses ILBM IFF files and extracts Bitmap image from it.

Supported chunks:

* BMHD
* CMAP
* BODY
* VERS
* JPEG

Supported compressed and uncompressed BODY chunk.

Example of usage:

```csharp
                //create IFF parser
                var iff = new IFF();
                //parse file
                iff.Parse("test.iff");
                //save Bitmap
                iff.Bitmap.Save("test.png");
```
