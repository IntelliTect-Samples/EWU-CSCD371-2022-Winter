# Homework

- Homework assignments will show up as a new branch on the main IntelliTect repository.
- The README.md file at the root of the repository will contain all of the details for the assignment.
- The Assignment.md file at the root of the repository will contain the [peer review report](#Peer-Review) to submit.

## Creating an Assignment Branch

Before starting an assignment ensure that [your fork is in-sync](https://help.github.com/articles/syncing-a-fork/) with the IntelliTect repository. Then, create a new branch for the assignment. Each assignment *must* be based on the given assignment branch. Keep your PRs as small as possible and focused on the assignment. The goal of the assignment is **not** to keep a running version of the project.

#### GitKraken
1. On the left panel in the REMOTE section. Right click on the intellitect remote and select Fetch intellitect.
2. Locate the desired assignment branch and select Create branch here. 
3. Give your branch a name. I suggest mirroring the name of the original assignment branch (Assignment1, Assignment2, etc). This creates a branch on your _local_ repository, that is _based_ on the original assignment branch.
4. When you have completed the work, push your changes. The first time you do this it may prompt you to specify a _remote_ branch name. Again, use the same name for the branch to avoid confusion. You now have a copy of the branch on your _fork_. 
5. As soon as there is substantial work completed, create a pull request back to the _original assignment branch_ (not to the main branch). The assignment does not need to be fully complete to start a pull request. As you push future changes to your branch, the pull request to automatically update with those changes.
  
#### Command Line
1. Ensure you are in the root of the repository.
2. Fetch the commits from the IntelliTect repository. `git fetch intellitect`
3. Create a new local branch from the remote branch `git checkout -b Assignment3 intellitect/Assignment3`
4. Unset the upstream branch so it no longer points at the original in the intellitect remote `git branch --unset-upstream`
5. When you have completed the work, push the your changes setting the upstream branch to one in your fork. `git push --set-upstream origin Assignment3`
6. As soon as there is substantial work completed, create a pull request back to the _original assignment branch_ (not to the main branch). The assignment does not need to be fully complete to start a pull request. As you push future changes to your branch, the pull request to automatically update with those changes.

## Submitting a pull request

Do not open a pull request until you are ready to have someone else [review it](#peer-review). If you just want to post something to get feedback submit it as [draft pull request](https://github.blog/2019-02-14-introducing-draft-pull-requests/).

1. Open your repository on GitHub
2. Click the New pull request button
3. Set the source and target repository and branch. Pay attention to the direction of the arrow icon.
4. Click Create pull request.
5. Ensure the title includes "Assignment `<number>`"
6. If you [paired](Homework-Grading.md#Pairing), ensure the other person's name is included in the description. Enter any reasonable description. Please note: the title and description can be updated over time.

## Peer Review

All students are expected to perform a [code review](https://help.github.com/articles/about-pull-request-reviews/) of _someone else's PR_ (exception if you are [pairing](Homework-Grading#Pairing)). Ensure that you are marked as a reviewer on the PR (GitHub should do this automatically after you submit a review or comment). You can submit a review using the Comment status (it is not necessary to mark it as Approve or Request Changes). Make sure you submit the review. **Failing to submit the review, may result in the review not being counted.** 

Before starting a review, **immediately submit** a comment on the PR saying "I will review this", so other people do not start reviewing the same PR. 

No code review should be empty. There **must be at least one comment** (even if it is just indicating that you reviewed the work and it looked good). Be aware that [part of your grade](Homework-Grading.md#peer-review) is dependent on doing good code reviews. 
[Code Review Guidelines](https://intellitect.com/code-reviews/)

A Peer Review, is simply a code review where you fill out the table in the `Assignment.md` file. After filling it out, copy and paste the content of it into a comment on the pull request. 

Feel free to do multiple code reviews for an assignment but no more than one peer review.

If your assignment fails to get a Peer Review, please post in the gitter chat requesting one.

If you [pair](Homework-Grading.md#pairing) with someone on the assignment **you both perform your own peer review**. 

## Final corrections 
This is your opportunity to correct anything caught by the peer review. If you completed the assignment, and the peer review did not find anything, you do not need to do anything here; these are free points. 

For all comment given during the peer review, you should either make the change or leave a reply indicating why no change is needed.