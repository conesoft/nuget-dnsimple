﻿namespace Conesoft.DNSimple.Records;

public class Response
{
    public Record[] data { get; set; }
    public Pagination pagination { get; set; }
}