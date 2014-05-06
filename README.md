What Is This...?
-----------------
This tool can be used to monitor a set of Hudson builds and play an alarm once a build fails or goes unstable.

How To Use the Tool...?
------------------------

Open the **App.config** file and edit the values of the following entries.

 - **alarmFile** - Provide the full path for the sound file that should be played once there is a build failure.
 - **monitoringFrequency** - How frequently should the monitoring be done (in seconds)

Then add the build jobs to the **buildJobs** section. Ex:

```xml
<add key="NETBEANS_BUILDER" value="http://deadlock.netbeans.org/job/trunk/"/>
```

Add a new key-value pair for each build job that needs to be monitored.

_Please note that the value that is given for **key** should be unique._