# ObjectPoolingAndClosestNeighbour

Unity 2020.3.9f1

______________________________________________________________________________________________________________________________________________________________________

Open ObjectPoolerTestScene to test the Object Pooler.
Bomb Spawner spawns new bombs, in 1 of 5 pre assigned positions. The bombs are taken from the object pooler.
Default pool size in Object Pooler is exposed to the editor as well as the Spawn Frequency in Bomb Spawner.
If you change the settings to spawn bombs faster then they return to the pool, new bombs will be instantiated to increase the pool size.

______________________________________________________________________________________________________________________________________________________________________

FindNearestNeighbourTestScene to test the 'Find Nearest Neighbour' Script.
Each instance of the class adds themself to a static list in 'OnEnable' and finds the closest neighbour with the script attached, keeps a reference to it, as well as the distance and draws a line to it in editor (Gizmo)

Every time an object with this script attached becomes enabled or disabled, all instances of the class takes that into account.
This is done via delegate functuions, NewNeighbour and NeighbourDisabled.
Performance is kept in mind. If a new neighbour is enabled, it's distance is only compared to the current closest.
Likewise, a new closest neighbour is searched only if the disabled instance was the previous closest neighbour.
