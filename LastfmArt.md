Another last.fm related small tool. Used for downloading and managing artist images.

# Introduction #

A rewritten version of the last artistArtGui version with some more features.


# New features #

  * Show multiple artists in different tabs.
  * Display artist's bio if selected.
  * Change display mode of local and all
  * Can display all downloaded images in different tabs according to artist names.
  * Will alert user when quitting with unfinished downloads.
  * New commandline parameter format, can get multiple artists.

## Commandline Parameter Format ##

```
lastFmArtist.exe /artist [aritstname] /num [number of images per page] /path [save path]
```

Can set multiple artists to [artistname](artistname.md) like
```
lastFmArtist.exe /artist "paramore" "taylor swift" /num 10 /path "f:\artistart"
```