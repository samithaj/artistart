# Commandline Version #
## Introduction ##
it runs in command line,using Last.fm's api to download specific artist's photos.
**require .Net 2.0**
I developed it specially for foobar2000 with foo\_run component,but it will also work with other player if they support anything like foo\_run.

## Usage ##

art.exe `<artist`> `<path`> `<number`>

`<artist`>:artist name

`<path`>:music file's path

`<number`>:number of photos to download.


## Source Code ##
It's a very small project.
Check out the source code:
```
svn checkout http://artistart.googlecode.com/svn/trunk/ artistart-read-only
```


# Last.fm Artist #

Newest GUI version. Should always prefer this to the original Gui version.



# Gui Version #
## Usage ##
First browse the destination path by clicking on the disabled(gray) textbox,
Then input the artist name in the other textbox, number in the numberbox.
Click "Get list"..and wait until the list with preview is fetched.

Click download under each preview.Then the image will be download to destination
path with number identifier.(Thus, [Issue 1](https://code.google.com/p/artistart/issues/detail?id=1) won't happen again)
Note: If previous downloaded file is found, using local file for preview, "Download" label
would be changed to "Downloaded".
