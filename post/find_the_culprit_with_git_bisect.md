{"title":"Find the culprit with git bisect","pubDate":"2014-03-18T01:15:46.358Z","author":"Christof Jans"}

# Find the culprit with git bisect

Suppose you are developing your application, merrily committing code when suddenly you realize that a bug has been introduced. You know for sure an earlier commit was correct but the last commit is not. The bug was introduced somewhere between these 2 commits, but where?  

You could test every commit since the last known good commit, but if there are many commits this could take a long time. Suppose the last know good commit is called `good`, the first known bad commit is called `bad` and there are 100 commits in the interval `[good,bad]`. A linear search has to test (on average) 50 commits.  

Luckily git has a built in tool to help you with this: `git bisect`. The bisect algorithm will find the commit that is in the 'middle' of `good` and `bad` (let's call it `middle`). If `middle` is determined to be good the interval is halved to `[middle, bad]`, otherwise it's halved to `[good, middle]`. Since the interval is halved each time, only $%log_2 100 \approx 7%$ tests are needed.  

Here is how it works:

    > git bisect start
    > git bisect good f45f0a85
    > git bisect bad 08ecc95d
    Bisecting: 100 revisions left to test after this (roughly 7 steps)
    [a167b78a47d89185a6450e41421b7aa936884fe1] added awesome sauce

`git bisect` starts the bisect task. `git bisect good f45f0a85` tells git the SHA of the last known good commit. `git bisect bad 08ecc95d` tells git the SHA of the first known bad commit. Git will then check out a commit for you to test. You must inform git whether this commit is good or bad. If it's good, type:

    git bisect good

If it's bad, type:

    git bisect bad

Based on the information you give, git will keep halving the interval until the culprit is found.

    a167b78a47d89185a6450e41421b7aa936884fe1 is the first bad commit
    commit a167b78a47d89185a6450e41421b7aa936884fe1
    Author: Christof Jans <christofjans@someplace.com>
    Date:   Mon Mar 17 21:13:41 2014 -0400

    small fix - no need to test

Git has found the culprit and gives you the hash, author date and message of the commit. Finally you can exit bisect mode with:

    git bisect reset

## Automating git bisect

`git bisect` drastically reduces the number of commits you have to test but you still have to manually test each commit. Luckily, `git bisect` supports scripting the test:

    git bisect start bad_commit good_commit
    git bisect run test_commit.sh

In this example `test_commit.sh` is a bash shell script to test if the commit is good or bad. If the commit is good the script should return 0, otherwise it should return a non-zero integer. Now `git bisect` will run fully automated. If you don't like writing bash shell scripts, you can just call a windows exe from the script:

    "c:\path_to_exe\test_commit.exe"

Again, the .exe should return 0 if the commit is good and a non-zero integer if the commit is bad.  

## Conclusion

Git bisect is a powerful tool to find bad commits quickly. It can be run in interactive mode or fully automated. Also note that if you find yourself using `git bisect` all the time, you might want to consider integrating unit tests in your build ;)  

Hope this helps.