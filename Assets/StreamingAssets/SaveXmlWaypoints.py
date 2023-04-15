import json
import string
from xml.dom import minidom
from matplotlib import pyplot as plt
from mpl_toolkits.mplot3d import Axes3D
import xml.etree.ElementTree as ET

from numpy import sin,cos

def rpy2quaternion(roll, pitch, yaw):
    x = round(sin(pitch/2)*sin(yaw/2)*cos(roll/2)+cos(pitch/2)*cos(yaw/2)*sin(roll/2),5)
    y = round(sin(pitch/2)*cos(yaw/2)*cos(roll/2)+cos(pitch/2)*sin(yaw/2)*sin(roll/2),5)
    z = round(cos(pitch/2)*sin(yaw/2)*cos(roll/2)-sin(pitch/2)*cos(yaw/2)*sin(roll/2),5)
    w = round(cos(pitch/2)*cos(yaw/2)*cos(roll/2)-sin(pitch/2)*sin(yaw/2)*sin(roll/2),5)
    return (x, y, z, w)

if __name__ == '__main__':
    with open("waypoints_race04.json", "r") as f_agent:
        loadin = json.load(f_agent)
        waypoints_pos = loadin['way_points_pos']
        waypoints_rot = loadin['way_points_rot']
    count = len(waypoints_pos)
    root = ET.Element("waypoints")

    #定义坐标轴
    fig = plt.figure()
    ax1 = plt.axes(projection='3d')
    index = 0
    for i in range(0,count,2):
        ax1.scatter3D(waypoints_pos[i]['x'],waypoints_pos[i]['z'],waypoints_pos[i]['y'], cmap='Blues')  #绘制散点图
        
        waypoint_node = ET.Element("waypoint")
        waypoint_node.tail = "\n"
        waypoint_node.attrib = {'index':str(index)}
        index += 1

        positon_node = ET.Element("position")
        positon_node.tail = "\n"
        pos = (round(waypoints_pos[i]['x'],2),round(waypoints_pos[i]['y'],2),round(waypoints_pos[i]['z'],2))
        positon_node.text = str(pos)
        #waypoint_node.append(positon_node)
        

        rotation_node = ET.Element("rotation")
        rotation_node.tail = "\n"
        rot = rpy2quaternion(waypoints_rot[i]['x'],waypoints_rot[i]['y'],waypoints_rot[i]['z'])
        rotation_node.text = str(rot)
        #waypoint_node.append(rotation_node)

        scale_node = ET.Element("scale")
        scale_node.tail = "\n"
        scale_node.text = str((1.00, 1.00, 1.00))
        #waypoint_node.append(scale_node)

        waypoint_node.extend([positon_node,rotation_node,scale_node])
        root.append(waypoint_node)
        
    plt.show()
    
    #tree = ET.ElementTree(root)
    #tree.write("output.xml", encoding="utf-8", xml_declaration=True)  #保存时无缩进，添加缩进需要借用dom
    rawtext = ET.tostring(root)
    dom = minidom.parseString(rawtext)
    with open("output.xml", "w") as f:
        dom.writexml(f, indent="\t", newl="", encoding="utf-8")

