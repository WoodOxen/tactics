import json
import string
from xml.dom import minidom
from matplotlib import pyplot as plt
from mpl_toolkits.mplot3d import Axes3D
import xml.etree.ElementTree as ET


if __name__ == '__main__':
    with open("waypoints_race04.json", "r") as f_agent:
        loadin = json.load(f_agent)
        waypoints_pos = loadin['way_points_pos']
        waypoints_rot = loadin['way_points_rot']
    count = len(waypoints_pos)
    root = ET.Element("waypoints")

    lineX = []
    lineY = []
    Xmax = -10000
    Xmin = 10000
    Ymax = -10000
    Ymin = 10000

    # these two data is from RaceArea in unity. 
    Terrain_length = 750
    Terrain_width = 550

    for i in range(0,count,2):
        lineX.append(waypoints_pos[i]['x'])
        lineY.append(waypoints_pos[i]['z'])
        if(waypoints_pos[i]['x'] > Xmax):
            Xmax = waypoints_pos[i]['x']
        elif(waypoints_pos[i]['x'] < Xmin):
            Xmin = waypoints_pos[i]['x']
        if(waypoints_pos[i]['z'] > Ymax):
            Ymax = waypoints_pos[i]['z']
        elif(waypoints_pos[i]['z'] < Ymin):
            Ymin = waypoints_pos[i]['z']
    #fig = plt.figure()
    fig = plt.figure(figsize=((Xmax-Xmin)/100,(Ymax-Ymin)/100))
    #fig = plt.figure(figsize=(550/100,750/100))
    plt.xlim(0, Terrain_width)
    plt.ylim(0, Terrain_length)
    
    plt.plot(lineX, lineY, "-", linewidth = 13, c = 'w')
    
    plt.axis('off') # 关闭坐标轴
    #fig.show()
    #plt.set_aspect((Xmax-Xmin)/(Ymax-Ymin))
    fig.savefig("minimap_track01", transparent=True, bbox_inches='tight', pad_inches=0.0)