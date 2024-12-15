using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace hashes;

public class GhostsTask :
	IFactory<Document>, IFactory<Vector>, IFactory<Segment>, IFactory<Cat>, IFactory<Robot>,
	IMagic
{
	object ghost;
	byte[] DocumentContent = new byte[] { 1, 2 };
	Vector SegmentStart = new Vector(1, 2);

    public void DoMagic()
	{
		switch (ghost.GetType().Name)
		{
			case "Document":
                DocumentContent[1] = 1; ;
                break;
			case "Vector":
				((Vector)ghost).Add(new Vector(1, 1));
				break;
			case "Segment":
				SegmentStart.Add(new Vector(1, 1));
				break;
            case "Cat":
				((Cat)ghost).Rename("awrora");
				break;
			case "Robot":
				Robot.BatteryCapacity = 50;
				break;
		}
	}

    Document IFactory<Document>.Create()
    {
		if (ghost == null) ghost = new Document("1", Encoding.UTF8, DocumentContent);
		return (Document)ghost;
    }

    Vector IFactory<Vector>.Create()
	{
        if (ghost == null) ghost = new Vector(1, 1);
		return (Vector)ghost;
	}

	Segment IFactory<Segment>.Create()
	{
        if (ghost == null) ghost = new Segment(SegmentStart, new Vector(2, 2));
		return (Segment)ghost;
	}

	Cat IFactory<Cat>.Create()
	{
        if (ghost == null) ghost = new Cat("Awrora", "rys", new DateTime(2014, 05, 26));
		return (Cat)ghost;
	}
	Robot IFactory<Robot>.Create()
	{
        if (ghost == null) ghost = new Robot("first");
		return (Robot)ghost;
	}
}