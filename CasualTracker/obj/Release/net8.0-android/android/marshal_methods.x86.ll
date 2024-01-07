; ModuleID = 'marshal_methods.x86.ll'
source_filename = "marshal_methods.x86.ll"
target datalayout = "e-m:e-p:32:32-p270:32:32-p271:32:32-p272:64:64-f64:32:64-f80:32-n8:16:32-S128"
target triple = "i686-unknown-linux-android21"

%struct.MarshalMethodName = type {
	i64, ; uint64_t id
	ptr ; char* name
}

%struct.MarshalMethodsManagedClass = type {
	i32, ; uint32_t token
	ptr ; MonoClass klass
}

@assembly_image_cache = dso_local local_unnamed_addr global [136 x ptr] zeroinitializer, align 4

; Each entry maps hash of an assembly name to an index into the `assembly_image_cache` array
@assembly_image_cache_hashes = dso_local local_unnamed_addr constant [272 x i32] [
	i32 38948123, ; 0: ar\Microsoft.Maui.Controls.resources.dll => 0x2524d1b => 0
	i32 39109920, ; 1: Newtonsoft.Json.dll => 0x254c520 => 48
	i32 42244203, ; 2: he\Microsoft.Maui.Controls.resources.dll => 0x284986b => 9
	i32 42639949, ; 3: System.Threading.Thread => 0x28aa24d => 124
	i32 67008169, ; 4: zh-Hant\Microsoft.Maui.Controls.resources => 0x3fe76a9 => 33
	i32 72070932, ; 5: Microsoft.Maui.Graphics.dll => 0x44bb714 => 47
	i32 83839681, ; 6: ms\Microsoft.Maui.Controls.resources.dll => 0x4ff4ac1 => 17
	i32 117431740, ; 7: System.Runtime.InteropServices => 0x6ffddbc => 116
	i32 136584136, ; 8: zh-Hans\Microsoft.Maui.Controls.resources.dll => 0x8241bc8 => 32
	i32 140062828, ; 9: sk\Microsoft.Maui.Controls.resources.dll => 0x859306c => 25
	i32 165246403, ; 10: Xamarin.AndroidX.Collection.dll => 0x9d975c3 => 58
	i32 182336117, ; 11: Xamarin.AndroidX.SwipeRefreshLayout.dll => 0xade3a75 => 76
	i32 200717038, ; 12: CasualTracker.Persistence.dll => 0xbf6b2ee => 83
	i32 205061960, ; 13: System.ComponentModel => 0xc38ff48 => 92
	i32 230752869, ; 14: Microsoft.CSharp.dll => 0xdc10265 => 85
	i32 246610117, ; 15: System.Reflection.Emit.Lightweight => 0xeb2f8c5 => 113
	i32 283146587, ; 16: CasualTracker.Model.dll => 0x10e0795b => 82
	i32 317674968, ; 17: vi\Microsoft.Maui.Controls.resources => 0x12ef55d8 => 30
	i32 318968648, ; 18: Xamarin.AndroidX.Activity.dll => 0x13031348 => 54
	i32 321963286, ; 19: fr\Microsoft.Maui.Controls.resources.dll => 0x1330c516 => 8
	i32 342366114, ; 20: Xamarin.AndroidX.Lifecycle.Common => 0x146817a2 => 65
	i32 347068432, ; 21: SQLitePCLRaw.lib.e_sqlite3.android.dll => 0x14afd810 => 52
	i32 379916513, ; 22: System.Threading.Thread.dll => 0x16a510e1 => 124
	i32 385762202, ; 23: System.Memory.dll => 0x16fe439a => 103
	i32 395744057, ; 24: _Microsoft.Android.Resource.Designer => 0x17969339 => 34
	i32 409257351, ; 25: tr\Microsoft.Maui.Controls.resources.dll => 0x1864c587 => 28
	i32 442565967, ; 26: System.Collections => 0x1a61054f => 89
	i32 450948140, ; 27: Xamarin.AndroidX.Fragment.dll => 0x1ae0ec2c => 64
	i32 456227837, ; 28: System.Web.HttpUtility.dll => 0x1b317bfd => 126
	i32 459347974, ; 29: System.Runtime.Serialization.Primitives.dll => 0x1b611806 => 119
	i32 469710990, ; 30: System.dll => 0x1bff388e => 130
	i32 489220957, ; 31: es\Microsoft.Maui.Controls.resources.dll => 0x1d28eb5d => 6
	i32 498788369, ; 32: System.ObjectModel => 0x1dbae811 => 108
	i32 513247710, ; 33: Microsoft.Extensions.Primitives.dll => 0x1e9789de => 42
	i32 538707440, ; 34: th\Microsoft.Maui.Controls.resources.dll => 0x201c05f0 => 27
	i32 539058512, ; 35: Microsoft.Extensions.Logging => 0x20216150 => 39
	i32 627609679, ; 36: Xamarin.AndroidX.CustomView => 0x2568904f => 62
	i32 627931235, ; 37: nl\Microsoft.Maui.Controls.resources => 0x256d7863 => 19
	i32 672442732, ; 38: System.Collections.Concurrent => 0x2814a96c => 86
	i32 690569205, ; 39: System.Xml.Linq.dll => 0x29293ff5 => 127
	i32 748832960, ; 40: SQLitePCLRaw.batteries_v2 => 0x2ca248c0 => 50
	i32 759454413, ; 41: System.Net.Requests => 0x2d445acd => 106
	i32 775507847, ; 42: System.IO.Compression => 0x2e394f87 => 100
	i32 777317022, ; 43: sk\Microsoft.Maui.Controls.resources => 0x2e54ea9e => 25
	i32 789151979, ; 44: Microsoft.Extensions.Options => 0x2f0980eb => 41
	i32 804715423, ; 45: System.Data.Common => 0x2ff6fb9f => 94
	i32 823281589, ; 46: System.Private.Uri.dll => 0x311247b5 => 109
	i32 830298997, ; 47: System.IO.Compression.Brotli => 0x317d5b75 => 99
	i32 869139383, ; 48: hi\Microsoft.Maui.Controls.resources.dll => 0x33ce03b7 => 10
	i32 880668424, ; 49: ru\Microsoft.Maui.Controls.resources.dll => 0x347def08 => 24
	i32 904024072, ; 50: System.ComponentModel.Primitives.dll => 0x35e25008 => 90
	i32 918734561, ; 51: pt-BR\Microsoft.Maui.Controls.resources.dll => 0x36c2c6e1 => 21
	i32 955402788, ; 52: Newtonsoft.Json => 0x38f24a24 => 48
	i32 961460050, ; 53: it\Microsoft.Maui.Controls.resources.dll => 0x394eb752 => 14
	i32 967690846, ; 54: Xamarin.AndroidX.Lifecycle.Common.dll => 0x39adca5e => 65
	i32 975874589, ; 55: System.Xml.XDocument => 0x3a2aaa1d => 129
	i32 990727110, ; 56: ro\Microsoft.Maui.Controls.resources.dll => 0x3b0d4bc6 => 23
	i32 992768348, ; 57: System.Collections.dll => 0x3b2c715c => 89
	i32 1012816738, ; 58: Xamarin.AndroidX.SavedState.dll => 0x3c5e5b62 => 75
	i32 1019214401, ; 59: System.Drawing => 0x3cbffa41 => 98
	i32 1028951442, ; 60: Microsoft.Extensions.DependencyInjection.Abstractions => 0x3d548d92 => 38
	i32 1035644815, ; 61: Xamarin.AndroidX.AppCompat => 0x3dbaaf8f => 55
	i32 1036536393, ; 62: System.Drawing.Primitives.dll => 0x3dc84a49 => 97
	i32 1043950537, ; 63: de\Microsoft.Maui.Controls.resources.dll => 0x3e396bc9 => 4
	i32 1044663988, ; 64: System.Linq.Expressions.dll => 0x3e444eb4 => 101
	i32 1052210849, ; 65: Xamarin.AndroidX.Lifecycle.ViewModel.dll => 0x3eb776a1 => 67
	i32 1082857460, ; 66: System.ComponentModel.TypeConverter => 0x408b17f4 => 91
	i32 1084122840, ; 67: Xamarin.Kotlin.StdLib => 0x409e66d8 => 80
	i32 1098259244, ; 68: System => 0x41761b2c => 130
	i32 1108272742, ; 69: sv\Microsoft.Maui.Controls.resources.dll => 0x420ee666 => 26
	i32 1117529484, ; 70: pl\Microsoft.Maui.Controls.resources.dll => 0x429c258c => 20
	i32 1118262833, ; 71: ko\Microsoft.Maui.Controls.resources => 0x42a75631 => 16
	i32 1168523401, ; 72: pt\Microsoft.Maui.Controls.resources => 0x45a64089 => 22
	i32 1178241025, ; 73: Xamarin.AndroidX.Navigation.Runtime.dll => 0x463a8801 => 72
	i32 1260983243, ; 74: cs\Microsoft.Maui.Controls.resources => 0x4b2913cb => 2
	i32 1292207520, ; 75: SQLitePCLRaw.core.dll => 0x4d0585a0 => 51
	i32 1293217323, ; 76: Xamarin.AndroidX.DrawerLayout.dll => 0x4d14ee2b => 63
	i32 1308624726, ; 77: hr\Microsoft.Maui.Controls.resources.dll => 0x4e000756 => 11
	i32 1324164729, ; 78: System.Linq => 0x4eed2679 => 102
	i32 1336711579, ; 79: zh-HK\Microsoft.Maui.Controls.resources.dll => 0x4fac999b => 31
	i32 1373134921, ; 80: zh-Hans\Microsoft.Maui.Controls.resources => 0x51d86049 => 32
	i32 1376866003, ; 81: Xamarin.AndroidX.SavedState => 0x52114ed3 => 75
	i32 1406073936, ; 82: Xamarin.AndroidX.CoordinatorLayout => 0x53cefc50 => 59
	i32 1408764838, ; 83: System.Runtime.Serialization.Formatters.dll => 0x53f80ba6 => 118
	i32 1430672901, ; 84: ar\Microsoft.Maui.Controls.resources => 0x55465605 => 0
	i32 1461004990, ; 85: es\Microsoft.Maui.Controls.resources => 0x57152abe => 6
	i32 1462112819, ; 86: System.IO.Compression.dll => 0x57261233 => 100
	i32 1465894101, ; 87: CasualTracker.Model => 0x575fc4d5 => 82
	i32 1469204771, ; 88: Xamarin.AndroidX.AppCompat.AppCompatResources => 0x57924923 => 56
	i32 1470490898, ; 89: Microsoft.Extensions.Primitives => 0x57a5e912 => 42
	i32 1480492111, ; 90: System.IO.Compression.Brotli.dll => 0x583e844f => 99
	i32 1526286932, ; 91: vi\Microsoft.Maui.Controls.resources.dll => 0x5af94a54 => 30
	i32 1543031311, ; 92: System.Text.RegularExpressions.dll => 0x5bf8ca0f => 123
	i32 1622152042, ; 93: Xamarin.AndroidX.Loader.dll => 0x60b0136a => 69
	i32 1624863272, ; 94: Xamarin.AndroidX.ViewPager2 => 0x60d97228 => 78
	i32 1636350590, ; 95: Xamarin.AndroidX.CursorAdapter => 0x6188ba7e => 61
	i32 1639515021, ; 96: System.Net.Http.dll => 0x61b9038d => 104
	i32 1639986890, ; 97: System.Text.RegularExpressions => 0x61c036ca => 123
	i32 1657153582, ; 98: System.Runtime => 0x62c6282e => 120
	i32 1658251792, ; 99: Xamarin.Google.Android.Material.dll => 0x62d6ea10 => 79
	i32 1677501392, ; 100: System.Net.Primitives.dll => 0x63fca3d0 => 105
	i32 1679769178, ; 101: System.Security.Cryptography => 0x641f3e5a => 121
	i32 1690936596, ; 102: CasualTracker.Persistence => 0x64c9a514 => 83
	i32 1711441057, ; 103: SQLitePCLRaw.lib.e_sqlite3.android => 0x660284a1 => 52
	i32 1729485958, ; 104: Xamarin.AndroidX.CardView.dll => 0x6715dc86 => 57
	i32 1743415430, ; 105: ca\Microsoft.Maui.Controls.resources => 0x67ea6886 => 1
	i32 1763938596, ; 106: System.Diagnostics.TraceSource.dll => 0x69239124 => 96
	i32 1766324549, ; 107: Xamarin.AndroidX.SwipeRefreshLayout => 0x6947f945 => 76
	i32 1770582343, ; 108: Microsoft.Extensions.Logging.dll => 0x6988f147 => 39
	i32 1780572499, ; 109: Mono.Android.Runtime.dll => 0x6a216153 => 134
	i32 1782862114, ; 110: ms\Microsoft.Maui.Controls.resources => 0x6a445122 => 17
	i32 1788241197, ; 111: Xamarin.AndroidX.Fragment => 0x6a96652d => 64
	i32 1793755602, ; 112: he\Microsoft.Maui.Controls.resources => 0x6aea89d2 => 9
	i32 1808609942, ; 113: Xamarin.AndroidX.Loader => 0x6bcd3296 => 69
	i32 1813058853, ; 114: Xamarin.Kotlin.StdLib.dll => 0x6c111525 => 80
	i32 1813201214, ; 115: Xamarin.Google.Android.Material => 0x6c13413e => 79
	i32 1818569960, ; 116: Xamarin.AndroidX.Navigation.UI.dll => 0x6c652ce8 => 73
	i32 1824175904, ; 117: System.Text.Encoding.Extensions => 0x6cbab720 => 122
	i32 1824722060, ; 118: System.Runtime.Serialization.Formatters => 0x6cc30c8c => 118
	i32 1828688058, ; 119: Microsoft.Extensions.Logging.Abstractions.dll => 0x6cff90ba => 40
	i32 1853025655, ; 120: sv\Microsoft.Maui.Controls.resources => 0x6e72ed77 => 26
	i32 1858542181, ; 121: System.Linq.Expressions => 0x6ec71a65 => 101
	i32 1870277092, ; 122: System.Reflection.Primitives => 0x6f7a29e4 => 114
	i32 1875935024, ; 123: fr\Microsoft.Maui.Controls.resources => 0x6fd07f30 => 8
	i32 1893218855, ; 124: cs\Microsoft.Maui.Controls.resources.dll => 0x70d83a27 => 2
	i32 1910275211, ; 125: System.Collections.NonGeneric.dll => 0x71dc7c8b => 87
	i32 1939592360, ; 126: System.Private.Xml.Linq => 0x739bd4a8 => 110
	i32 1953182387, ; 127: id\Microsoft.Maui.Controls.resources.dll => 0x746b32b3 => 13
	i32 1968388702, ; 128: Microsoft.Extensions.Configuration.dll => 0x75533a5e => 35
	i32 2003115576, ; 129: el\Microsoft.Maui.Controls.resources => 0x77651e38 => 5
	i32 2019465201, ; 130: Xamarin.AndroidX.Lifecycle.ViewModel => 0x785e97f1 => 67
	i32 2045470958, ; 131: System.Private.Xml => 0x79eb68ee => 111
	i32 2055257422, ; 132: Xamarin.AndroidX.Lifecycle.LiveData.Core.dll => 0x7a80bd4e => 66
	i32 2066184531, ; 133: de\Microsoft.Maui.Controls.resources => 0x7b277953 => 4
	i32 2070888862, ; 134: System.Diagnostics.TraceSource => 0x7b6f419e => 96
	i32 2079903147, ; 135: System.Runtime.dll => 0x7bf8cdab => 120
	i32 2090596640, ; 136: System.Numerics.Vectors => 0x7c9bf920 => 107
	i32 2103459038, ; 137: SQLitePCLRaw.provider.e_sqlite3.dll => 0x7d603cde => 53
	i32 2127167465, ; 138: System.Console => 0x7ec9ffe9 => 93
	i32 2142473426, ; 139: System.Collections.Specialized => 0x7fb38cd2 => 88
	i32 2159891885, ; 140: Microsoft.Maui => 0x80bd55ad => 45
	i32 2169148018, ; 141: hu\Microsoft.Maui.Controls.resources => 0x814a9272 => 12
	i32 2181898931, ; 142: Microsoft.Extensions.Options.dll => 0x820d22b3 => 41
	i32 2192057212, ; 143: Microsoft.Extensions.Logging.Abstractions => 0x82a8237c => 40
	i32 2193016926, ; 144: System.ObjectModel.dll => 0x82b6c85e => 108
	i32 2201107256, ; 145: Xamarin.KotlinX.Coroutines.Core.Jvm.dll => 0x83323b38 => 81
	i32 2201231467, ; 146: System.Net.Http => 0x8334206b => 104
	i32 2207618523, ; 147: it\Microsoft.Maui.Controls.resources => 0x839595db => 14
	i32 2266799131, ; 148: Microsoft.Extensions.Configuration.Abstractions => 0x871c9c1b => 36
	i32 2267897913, ; 149: CasualTracker => 0x872d6039 => 84
	i32 2279755925, ; 150: Xamarin.AndroidX.RecyclerView.dll => 0x87e25095 => 74
	i32 2303942373, ; 151: nb\Microsoft.Maui.Controls.resources => 0x89535ee5 => 18
	i32 2305521784, ; 152: System.Private.CoreLib.dll => 0x896b7878 => 132
	i32 2340441535, ; 153: System.Runtime.InteropServices.RuntimeInformation.dll => 0x8b804dbf => 115
	i32 2353062107, ; 154: System.Net.Primitives => 0x8c40e0db => 105
	i32 2366048013, ; 155: hu\Microsoft.Maui.Controls.resources.dll => 0x8d07070d => 12
	i32 2368005991, ; 156: System.Xml.ReaderWriter.dll => 0x8d24e767 => 128
	i32 2371007202, ; 157: Microsoft.Extensions.Configuration => 0x8d52b2e2 => 35
	i32 2395872292, ; 158: id\Microsoft.Maui.Controls.resources => 0x8ece1c24 => 13
	i32 2401565422, ; 159: System.Web.HttpUtility => 0x8f24faee => 126
	i32 2427813419, ; 160: hi\Microsoft.Maui.Controls.resources => 0x90b57e2b => 10
	i32 2435356389, ; 161: System.Console.dll => 0x912896e5 => 93
	i32 2465273461, ; 162: SQLitePCLRaw.batteries_v2.dll => 0x92f11675 => 50
	i32 2471841756, ; 163: netstandard.dll => 0x93554fdc => 131
	i32 2475788418, ; 164: Java.Interop.dll => 0x93918882 => 133
	i32 2480646305, ; 165: Microsoft.Maui.Controls => 0x93dba8a1 => 43
	i32 2503351294, ; 166: ko\Microsoft.Maui.Controls.resources.dll => 0x95361bfe => 16
	i32 2538310050, ; 167: System.Reflection.Emit.Lightweight.dll => 0x974b89a2 => 113
	i32 2550873716, ; 168: hr\Microsoft.Maui.Controls.resources => 0x980b3e74 => 11
	i32 2562349572, ; 169: Microsoft.CSharp => 0x98ba5a04 => 85
	i32 2576534780, ; 170: ja\Microsoft.Maui.Controls.resources.dll => 0x9992ccfc => 15
	i32 2585220780, ; 171: System.Text.Encoding.Extensions.dll => 0x9a1756ac => 122
	i32 2593496499, ; 172: pl\Microsoft.Maui.Controls.resources => 0x9a959db3 => 20
	i32 2605712449, ; 173: Xamarin.KotlinX.Coroutines.Core.Jvm => 0x9b500441 => 81
	i32 2617129537, ; 174: System.Private.Xml.dll => 0x9bfe3a41 => 111
	i32 2620871830, ; 175: Xamarin.AndroidX.CursorAdapter.dll => 0x9c375496 => 61
	i32 2626831493, ; 176: ja\Microsoft.Maui.Controls.resources => 0x9c924485 => 15
	i32 2664396074, ; 177: System.Xml.XDocument.dll => 0x9ecf752a => 129
	i32 2665622720, ; 178: System.Drawing.Primitives => 0x9ee22cc0 => 97
	i32 2676780864, ; 179: System.Data.Common.dll => 0x9f8c6f40 => 94
	i32 2724373263, ; 180: System.Runtime.Numerics.dll => 0xa262a30f => 117
	i32 2732626843, ; 181: Xamarin.AndroidX.Activity => 0xa2e0939b => 54
	i32 2737747696, ; 182: Xamarin.AndroidX.AppCompat.AppCompatResources.dll => 0xa32eb6f0 => 56
	i32 2740698338, ; 183: ca\Microsoft.Maui.Controls.resources.dll => 0xa35bbce2 => 1
	i32 2752995522, ; 184: pt-BR\Microsoft.Maui.Controls.resources => 0xa41760c2 => 21
	i32 2758225723, ; 185: Microsoft.Maui.Controls.Xaml => 0xa4672f3b => 44
	i32 2764765095, ; 186: Microsoft.Maui.dll => 0xa4caf7a7 => 45
	i32 2778768386, ; 187: Xamarin.AndroidX.ViewPager.dll => 0xa5a0a402 => 77
	i32 2785988530, ; 188: th\Microsoft.Maui.Controls.resources => 0xa60ecfb2 => 27
	i32 2801831435, ; 189: Microsoft.Maui.Graphics => 0xa7008e0b => 47
	i32 2810250172, ; 190: Xamarin.AndroidX.CoordinatorLayout.dll => 0xa78103bc => 59
	i32 2853208004, ; 191: Xamarin.AndroidX.ViewPager => 0xaa107fc4 => 77
	i32 2861189240, ; 192: Microsoft.Maui.Essentials => 0xaa8a4878 => 46
	i32 2909740682, ; 193: System.Private.CoreLib => 0xad6f1e8a => 132
	i32 2916838712, ; 194: Xamarin.AndroidX.ViewPager2.dll => 0xaddb6d38 => 78
	i32 2919462931, ; 195: System.Numerics.Vectors.dll => 0xae037813 => 107
	i32 2959614098, ; 196: System.ComponentModel.dll => 0xb0682092 => 92
	i32 2978675010, ; 197: Xamarin.AndroidX.DrawerLayout => 0xb18af942 => 63
	i32 3038032645, ; 198: _Microsoft.Android.Resource.Designer.dll => 0xb514b305 => 34
	i32 3053864966, ; 199: fi\Microsoft.Maui.Controls.resources.dll => 0xb6064806 => 7
	i32 3057625584, ; 200: Xamarin.AndroidX.Navigation.Common => 0xb63fa9f0 => 70
	i32 3059408633, ; 201: Mono.Android.Runtime => 0xb65adef9 => 134
	i32 3059793426, ; 202: System.ComponentModel.Primitives => 0xb660be12 => 90
	i32 3159123045, ; 203: System.Reflection.Primitives.dll => 0xbc4c6465 => 114
	i32 3178803400, ; 204: Xamarin.AndroidX.Navigation.Fragment.dll => 0xbd78b0c8 => 71
	i32 3220365878, ; 205: System.Threading => 0xbff2e236 => 125
	i32 3258312781, ; 206: Xamarin.AndroidX.CardView => 0xc235e84d => 57
	i32 3286872994, ; 207: SQLite-net.dll => 0xc3e9b3a2 => 49
	i32 3305363605, ; 208: fi\Microsoft.Maui.Controls.resources => 0xc503d895 => 7
	i32 3316684772, ; 209: System.Net.Requests.dll => 0xc5b097e4 => 106
	i32 3317135071, ; 210: Xamarin.AndroidX.CustomView.dll => 0xc5b776df => 62
	i32 3346324047, ; 211: Xamarin.AndroidX.Navigation.Runtime => 0xc774da4f => 72
	i32 3357674450, ; 212: ru\Microsoft.Maui.Controls.resources => 0xc8220bd2 => 24
	i32 3360279109, ; 213: SQLitePCLRaw.core => 0xc849ca45 => 51
	i32 3362522851, ; 214: Xamarin.AndroidX.Core => 0xc86c06e3 => 60
	i32 3366347497, ; 215: Java.Interop => 0xc8a662e9 => 133
	i32 3374999561, ; 216: Xamarin.AndroidX.RecyclerView => 0xc92a6809 => 74
	i32 3381016424, ; 217: da\Microsoft.Maui.Controls.resources => 0xc9863768 => 3
	i32 3428513518, ; 218: Microsoft.Extensions.DependencyInjection.dll => 0xcc5af6ee => 37
	i32 3430777524, ; 219: netstandard => 0xcc7d82b4 => 131
	i32 3458724246, ; 220: pt\Microsoft.Maui.Controls.resources.dll => 0xce27f196 => 22
	i32 3471940407, ; 221: System.ComponentModel.TypeConverter.dll => 0xcef19b37 => 91
	i32 3476120550, ; 222: Mono.Android => 0xcf3163e6 => 135
	i32 3484440000, ; 223: ro\Microsoft.Maui.Controls.resources => 0xcfb055c0 => 23
	i32 3509114376, ; 224: System.Xml.Linq => 0xd128d608 => 127
	i32 3580758918, ; 225: zh-HK\Microsoft.Maui.Controls.resources => 0xd56e0b86 => 31
	i32 3592228221, ; 226: zh-Hant\Microsoft.Maui.Controls.resources.dll => 0xd61d0d7d => 33
	i32 3608519521, ; 227: System.Linq.dll => 0xd715a361 => 102
	i32 3624195450, ; 228: System.Runtime.InteropServices.RuntimeInformation => 0xd804d57a => 115
	i32 3641597786, ; 229: Xamarin.AndroidX.Lifecycle.LiveData.Core => 0xd90e5f5a => 66
	i32 3643446276, ; 230: tr\Microsoft.Maui.Controls.resources => 0xd92a9404 => 28
	i32 3643854240, ; 231: Xamarin.AndroidX.Navigation.Fragment => 0xd930cda0 => 71
	i32 3657292374, ; 232: Microsoft.Extensions.Configuration.Abstractions.dll => 0xd9fdda56 => 36
	i32 3672681054, ; 233: Mono.Android.dll => 0xdae8aa5e => 135
	i32 3724971120, ; 234: Xamarin.AndroidX.Navigation.Common.dll => 0xde068c70 => 70
	i32 3748608112, ; 235: System.Diagnostics.DiagnosticSource => 0xdf6f3870 => 95
	i32 3751619990, ; 236: da\Microsoft.Maui.Controls.resources.dll => 0xdf9d2d96 => 3
	i32 3754567612, ; 237: SQLitePCLRaw.provider.e_sqlite3 => 0xdfca27bc => 53
	i32 3786282454, ; 238: Xamarin.AndroidX.Collection => 0xe1ae15d6 => 58
	i32 3792276235, ; 239: System.Collections.NonGeneric => 0xe2098b0b => 87
	i32 3802395368, ; 240: System.Collections.Specialized.dll => 0xe2a3f2e8 => 88
	i32 3823082795, ; 241: System.Security.Cryptography.dll => 0xe3df9d2b => 121
	i32 3841636137, ; 242: Microsoft.Extensions.DependencyInjection.Abstractions.dll => 0xe4fab729 => 38
	i32 3849253459, ; 243: System.Runtime.InteropServices.dll => 0xe56ef253 => 116
	i32 3876362041, ; 244: SQLite-net => 0xe70c9739 => 49
	i32 3896106733, ; 245: System.Collections.Concurrent.dll => 0xe839deed => 86
	i32 3896760992, ; 246: Xamarin.AndroidX.Core.dll => 0xe843daa0 => 60
	i32 3920221145, ; 247: nl\Microsoft.Maui.Controls.resources.dll => 0xe9a9d3d9 => 19
	i32 3928044579, ; 248: System.Xml.ReaderWriter => 0xea213423 => 128
	i32 3931092270, ; 249: Xamarin.AndroidX.Navigation.UI => 0xea4fb52e => 73
	i32 3955647286, ; 250: Xamarin.AndroidX.AppCompat.dll => 0xebc66336 => 55
	i32 4025784931, ; 251: System.Memory => 0xeff49a63 => 103
	i32 4046471985, ; 252: Microsoft.Maui.Controls.Xaml.dll => 0xf1304331 => 44
	i32 4054681211, ; 253: System.Reflection.Emit.ILGeneration => 0xf1ad867b => 112
	i32 4068434129, ; 254: System.Private.Xml.Linq.dll => 0xf27f60d1 => 110
	i32 4073602200, ; 255: System.Threading.dll => 0xf2ce3c98 => 125
	i32 4091086043, ; 256: el\Microsoft.Maui.Controls.resources.dll => 0xf3d904db => 5
	i32 4094352644, ; 257: Microsoft.Maui.Essentials.dll => 0xf40add04 => 46
	i32 4099507663, ; 258: System.Drawing.dll => 0xf45985cf => 98
	i32 4100113165, ; 259: System.Private.Uri => 0xf462c30d => 109
	i32 4103439459, ; 260: uk\Microsoft.Maui.Controls.resources.dll => 0xf4958463 => 29
	i32 4126470640, ; 261: Microsoft.Extensions.DependencyInjection => 0xf5f4f1f0 => 37
	i32 4147896353, ; 262: System.Reflection.Emit.ILGeneration.dll => 0xf73be021 => 112
	i32 4150914736, ; 263: uk\Microsoft.Maui.Controls.resources => 0xf769eeb0 => 29
	i32 4181436372, ; 264: System.Runtime.Serialization.Primitives => 0xf93ba7d4 => 119
	i32 4182413190, ; 265: Xamarin.AndroidX.Lifecycle.ViewModelSavedState.dll => 0xf94a8f86 => 68
	i32 4213026141, ; 266: System.Diagnostics.DiagnosticSource.dll => 0xfb1dad5d => 95
	i32 4240110698, ; 267: CasualTracker.dll => 0xfcbaf46a => 84
	i32 4249188766, ; 268: nb\Microsoft.Maui.Controls.resources.dll => 0xfd45799e => 18
	i32 4271975918, ; 269: Microsoft.Maui.Controls.dll => 0xfea12dee => 43
	i32 4274976490, ; 270: System.Runtime.Numerics => 0xfecef6ea => 117
	i32 4292120959 ; 271: Xamarin.AndroidX.Lifecycle.ViewModelSavedState => 0xffd4917f => 68
], align 4

@assembly_image_cache_indices = dso_local local_unnamed_addr constant [272 x i32] [
	i32 0, ; 0
	i32 48, ; 1
	i32 9, ; 2
	i32 124, ; 3
	i32 33, ; 4
	i32 47, ; 5
	i32 17, ; 6
	i32 116, ; 7
	i32 32, ; 8
	i32 25, ; 9
	i32 58, ; 10
	i32 76, ; 11
	i32 83, ; 12
	i32 92, ; 13
	i32 85, ; 14
	i32 113, ; 15
	i32 82, ; 16
	i32 30, ; 17
	i32 54, ; 18
	i32 8, ; 19
	i32 65, ; 20
	i32 52, ; 21
	i32 124, ; 22
	i32 103, ; 23
	i32 34, ; 24
	i32 28, ; 25
	i32 89, ; 26
	i32 64, ; 27
	i32 126, ; 28
	i32 119, ; 29
	i32 130, ; 30
	i32 6, ; 31
	i32 108, ; 32
	i32 42, ; 33
	i32 27, ; 34
	i32 39, ; 35
	i32 62, ; 36
	i32 19, ; 37
	i32 86, ; 38
	i32 127, ; 39
	i32 50, ; 40
	i32 106, ; 41
	i32 100, ; 42
	i32 25, ; 43
	i32 41, ; 44
	i32 94, ; 45
	i32 109, ; 46
	i32 99, ; 47
	i32 10, ; 48
	i32 24, ; 49
	i32 90, ; 50
	i32 21, ; 51
	i32 48, ; 52
	i32 14, ; 53
	i32 65, ; 54
	i32 129, ; 55
	i32 23, ; 56
	i32 89, ; 57
	i32 75, ; 58
	i32 98, ; 59
	i32 38, ; 60
	i32 55, ; 61
	i32 97, ; 62
	i32 4, ; 63
	i32 101, ; 64
	i32 67, ; 65
	i32 91, ; 66
	i32 80, ; 67
	i32 130, ; 68
	i32 26, ; 69
	i32 20, ; 70
	i32 16, ; 71
	i32 22, ; 72
	i32 72, ; 73
	i32 2, ; 74
	i32 51, ; 75
	i32 63, ; 76
	i32 11, ; 77
	i32 102, ; 78
	i32 31, ; 79
	i32 32, ; 80
	i32 75, ; 81
	i32 59, ; 82
	i32 118, ; 83
	i32 0, ; 84
	i32 6, ; 85
	i32 100, ; 86
	i32 82, ; 87
	i32 56, ; 88
	i32 42, ; 89
	i32 99, ; 90
	i32 30, ; 91
	i32 123, ; 92
	i32 69, ; 93
	i32 78, ; 94
	i32 61, ; 95
	i32 104, ; 96
	i32 123, ; 97
	i32 120, ; 98
	i32 79, ; 99
	i32 105, ; 100
	i32 121, ; 101
	i32 83, ; 102
	i32 52, ; 103
	i32 57, ; 104
	i32 1, ; 105
	i32 96, ; 106
	i32 76, ; 107
	i32 39, ; 108
	i32 134, ; 109
	i32 17, ; 110
	i32 64, ; 111
	i32 9, ; 112
	i32 69, ; 113
	i32 80, ; 114
	i32 79, ; 115
	i32 73, ; 116
	i32 122, ; 117
	i32 118, ; 118
	i32 40, ; 119
	i32 26, ; 120
	i32 101, ; 121
	i32 114, ; 122
	i32 8, ; 123
	i32 2, ; 124
	i32 87, ; 125
	i32 110, ; 126
	i32 13, ; 127
	i32 35, ; 128
	i32 5, ; 129
	i32 67, ; 130
	i32 111, ; 131
	i32 66, ; 132
	i32 4, ; 133
	i32 96, ; 134
	i32 120, ; 135
	i32 107, ; 136
	i32 53, ; 137
	i32 93, ; 138
	i32 88, ; 139
	i32 45, ; 140
	i32 12, ; 141
	i32 41, ; 142
	i32 40, ; 143
	i32 108, ; 144
	i32 81, ; 145
	i32 104, ; 146
	i32 14, ; 147
	i32 36, ; 148
	i32 84, ; 149
	i32 74, ; 150
	i32 18, ; 151
	i32 132, ; 152
	i32 115, ; 153
	i32 105, ; 154
	i32 12, ; 155
	i32 128, ; 156
	i32 35, ; 157
	i32 13, ; 158
	i32 126, ; 159
	i32 10, ; 160
	i32 93, ; 161
	i32 50, ; 162
	i32 131, ; 163
	i32 133, ; 164
	i32 43, ; 165
	i32 16, ; 166
	i32 113, ; 167
	i32 11, ; 168
	i32 85, ; 169
	i32 15, ; 170
	i32 122, ; 171
	i32 20, ; 172
	i32 81, ; 173
	i32 111, ; 174
	i32 61, ; 175
	i32 15, ; 176
	i32 129, ; 177
	i32 97, ; 178
	i32 94, ; 179
	i32 117, ; 180
	i32 54, ; 181
	i32 56, ; 182
	i32 1, ; 183
	i32 21, ; 184
	i32 44, ; 185
	i32 45, ; 186
	i32 77, ; 187
	i32 27, ; 188
	i32 47, ; 189
	i32 59, ; 190
	i32 77, ; 191
	i32 46, ; 192
	i32 132, ; 193
	i32 78, ; 194
	i32 107, ; 195
	i32 92, ; 196
	i32 63, ; 197
	i32 34, ; 198
	i32 7, ; 199
	i32 70, ; 200
	i32 134, ; 201
	i32 90, ; 202
	i32 114, ; 203
	i32 71, ; 204
	i32 125, ; 205
	i32 57, ; 206
	i32 49, ; 207
	i32 7, ; 208
	i32 106, ; 209
	i32 62, ; 210
	i32 72, ; 211
	i32 24, ; 212
	i32 51, ; 213
	i32 60, ; 214
	i32 133, ; 215
	i32 74, ; 216
	i32 3, ; 217
	i32 37, ; 218
	i32 131, ; 219
	i32 22, ; 220
	i32 91, ; 221
	i32 135, ; 222
	i32 23, ; 223
	i32 127, ; 224
	i32 31, ; 225
	i32 33, ; 226
	i32 102, ; 227
	i32 115, ; 228
	i32 66, ; 229
	i32 28, ; 230
	i32 71, ; 231
	i32 36, ; 232
	i32 135, ; 233
	i32 70, ; 234
	i32 95, ; 235
	i32 3, ; 236
	i32 53, ; 237
	i32 58, ; 238
	i32 87, ; 239
	i32 88, ; 240
	i32 121, ; 241
	i32 38, ; 242
	i32 116, ; 243
	i32 49, ; 244
	i32 86, ; 245
	i32 60, ; 246
	i32 19, ; 247
	i32 128, ; 248
	i32 73, ; 249
	i32 55, ; 250
	i32 103, ; 251
	i32 44, ; 252
	i32 112, ; 253
	i32 110, ; 254
	i32 125, ; 255
	i32 5, ; 256
	i32 46, ; 257
	i32 98, ; 258
	i32 109, ; 259
	i32 29, ; 260
	i32 37, ; 261
	i32 112, ; 262
	i32 29, ; 263
	i32 119, ; 264
	i32 68, ; 265
	i32 95, ; 266
	i32 84, ; 267
	i32 18, ; 268
	i32 43, ; 269
	i32 117, ; 270
	i32 68 ; 271
], align 4

@marshal_methods_number_of_classes = dso_local local_unnamed_addr constant i32 0, align 4

@marshal_methods_class_cache = dso_local local_unnamed_addr global [0 x %struct.MarshalMethodsManagedClass] zeroinitializer, align 4

; Names of classes in which marshal methods reside
@mm_class_names = dso_local local_unnamed_addr constant [0 x ptr] zeroinitializer, align 4

@mm_method_names = dso_local local_unnamed_addr constant [1 x %struct.MarshalMethodName] [
	%struct.MarshalMethodName {
		i64 0, ; id 0x0; name: 
		ptr @.MarshalMethodName.0_name; char* name
	} ; 0
], align 8

; get_function_pointer (uint32_t mono_image_index, uint32_t class_index, uint32_t method_token, void*& target_ptr)
@get_function_pointer = internal dso_local unnamed_addr global ptr null, align 4

; Functions

; Function attributes: "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8" uwtable willreturn
define void @xamarin_app_init(ptr nocapture noundef readnone %env, ptr noundef %fn) local_unnamed_addr #0
{
	%fnIsNull = icmp eq ptr %fn, null
	br i1 %fnIsNull, label %1, label %2

1: ; preds = %0
	%putsResult = call noundef i32 @puts(ptr @.str.0)
	call void @abort()
	unreachable 

2: ; preds = %1, %0
	store ptr %fn, ptr @get_function_pointer, align 4, !tbaa !3
	ret void
}

; Strings
@.str.0 = private unnamed_addr constant [40 x i8] c"get_function_pointer MUST be specified\0A\00", align 1

;MarshalMethodName
@.MarshalMethodName.0_name = private unnamed_addr constant [1 x i8] c"\00", align 1

; External functions

; Function attributes: noreturn "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8"
declare void @abort() local_unnamed_addr #2

; Function attributes: nofree nounwind
declare noundef i32 @puts(ptr noundef) local_unnamed_addr #1
attributes #0 = { "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8" "stackrealign" "target-cpu"="i686" "target-features"="+cx8,+mmx,+sse,+sse2,+sse3,+ssse3,+x87" "tune-cpu"="generic" uwtable willreturn }
attributes #1 = { nofree nounwind }
attributes #2 = { noreturn "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8" "stackrealign" "target-cpu"="i686" "target-features"="+cx8,+mmx,+sse,+sse2,+sse3,+ssse3,+x87" "tune-cpu"="generic" }

; Metadata
!llvm.module.flags = !{!0, !1, !7}
!0 = !{i32 1, !"wchar_size", i32 4}
!1 = !{i32 7, !"PIC Level", i32 2}
!llvm.ident = !{!2}
!2 = !{!"Xamarin.Android remotes/origin/release/8.0.1xx @ f1b7113872c8db3dfee70d11925e81bb752dc8d0"}
!3 = !{!4, !4, i64 0}
!4 = !{!"any pointer", !5, i64 0}
!5 = !{!"omnipotent char", !6, i64 0}
!6 = !{!"Simple C++ TBAA"}
!7 = !{i32 1, !"NumRegisterParameters", i32 0}
